using ExcelDataReader;

namespace JSONConverter
{
    public partial class JSONConverterForm : System.Windows.Forms.Form
    {
        public JSONConverterForm()
        {
            InitializeComponent();
            if (System.IO.File.Exists(Program.ConfigFilePath))
            {
                var configFile = System.IO.File.ReadAllText(Program.ConfigFilePath);
                try
                {   Program.Config = Newtonsoft.Json.JsonConvert.DeserializeObject<JSONConverterConfig>(configFile);
                    OriginalPathText.Text = Program.Config.OriginalPath;
                    OutputPathText.Text = Program.Config.OutputPath;
                    PrintResultText(BatchResultText, "설정 파일을 불러왔습니다.");
                }
                catch (System.Exception e)
                {
                    ErrorResultText(BatchResultText, "오류가 발생했습니다.");
                    ErrorResultText(BatchResultText, e.Message);
                }
            }
        }

        private void OriginalPathSelectButton_Click(object sender, System.EventArgs e)
        {
            if (OriginalPathDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                OriginalPathText.Text = OriginalPathDialog.SelectedPath;
                FolderPath_KeyEvent(null, null);
            }
        }

        private void OutputPathSelectButton_Click(object sender, System.EventArgs e)
        {
            if (OutputPathDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                OutputPathText.Text = OutputPathDialog.SelectedPath;
                FolderPath_KeyEvent(null, null);
            }
        }

        private void FolderPath_KeyEvent(object sender, System.EventArgs e)
        {
            Program.Config.OriginalPath = OriginalPathText.Text;
            Program.Config.OutputPath = OutputPathText.Text;
            SaveConfigFile();
        }

        private void CovertButton_Click(object sender, System.EventArgs e)
        {
            BatchCovertButton.Enabled = false;

            if (System.IO.Directory.Exists(OriginalPathText.Text) == false)
            {
                ErrorResultText(BatchResultText, "원본 폴더 경로가 존재하지 않습니다.");
                BatchCovertButton.Enabled = true;
                return;
            }

            //PrintResultText("원본 폴더 확인 완료.");

            if (System.IO.Directory.Exists(OutputPathText.Text) == false)
            {
                var result = System.IO.Directory.CreateDirectory(OutputPathText.Text);
                if (result.Exists == false)
                {
                    ErrorResultText(BatchResultText, "출력 폴더를 확인할 수 없습니다.");
                    BatchCovertButton.Enabled = true;
                    return;
                }
                else
                {
                    //PrintResultText("출력 폴더 생성 완료.");
                }
            }
            else
            {
                //PrintResultText("출력 폴더 확인 완료.");
            }

            var fileList = new System.Collections.Generic.List<string>();
            string[] files = System.IO.Directory.GetFiles(OriginalPathText.Text);
            
            foreach (var file in files)
            {
                string[] split = file.Split('.');
                if (split[split.Length - 1] == "xlsx")
                {
                    fileList.Add(file);
                }
            }

            if (fileList.Count == 0)
            {
                ErrorResultText(BatchResultText, "원본 폴더에 엑셀 파일이 존재하지 않습니다.");
                BatchCovertButton.Enabled = true;
                return;
            }

            PrintResultText(BatchResultText, string.Format("엑셀 파일 {0}개 확인.", fileList.Count));

            foreach (var file in files)
            {
                try
                {
                    Convert(file, OutputPathText.Text, BatchResultText);
                }
                catch (System.Exception ex)
                {
                    ErrorResultText(BatchResultText, string.Format("오류가 발생했습니다. {0}", file));
                    ErrorResultText(BatchResultText, ex.Message);
                }
            }

            PrintResultText(BatchResultText, "");
            PrintResultText(BatchResultText, "Excel to JSON 변환 완료했습니다.");

            BatchCovertButton.Enabled = true;
        }

        #region Single

        private void SinglePathSelectButton_Click(object sender, System.EventArgs e)
        {
            if (SinglePathDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SinglePathText.Text = SinglePathDialog.FileName;
            }
        }

        private void SingleCovertButton_Click(object sender, System.EventArgs e)
        {
            Convert(SinglePathText.Text, SinglePathText.Text.Substring(0, SinglePathText.Text.LastIndexOf('\\')), SingleResultText);
        }

        #endregion

        #region Util

        private void Convert(string filePath, string outputPath, System.Windows.Forms.RichTextBox element)
        {
            PrintResultText(element, "");
            PrintResultText(element, string.Format("변환시작 {0}", filePath));
            
            using (var stream = System.IO.File.Open(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                var excelData = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>>>();
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet();
                    var sheetEnumerator = result.Tables.GetEnumerator();
                    var sheetData = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>>();
                    while (sheetEnumerator.MoveNext())
                    {
                        var sheet = (System.Data.DataTable)sheetEnumerator.Current;

                        if (sheet.TableName == "overview")
                        {
                            continue;
                        }

                        int rowIndex = 0;
                        var columnNames = new System.Collections.Generic.Dictionary<int, string>();
                        var rowList = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>();
                        var rowEnumerator = sheet.Rows.GetEnumerator();
                        while (rowEnumerator.MoveNext())
                        {
                            var row = (System.Data.DataRow)rowEnumerator.Current;
                            var rowData = new System.Collections.Generic.Dictionary<string, string>();
                            for (int i = 0; i < row.ItemArray.Length; i++)
                            {
                                if (row.ItemArray[i].ToString() == string.Empty)
                                {
                                    break;
                                }

                                if (rowIndex == 0)
                                {
                                    columnNames.Add(i, row.ItemArray[i].ToString());
                                }
                                else
                                {
                                    if (columnNames.ContainsKey(i))
                                    {
                                        if (row.ItemArray[i].ToString() == string.Empty)
                                        {
                                            break;
                                        }

                                        rowData.Add(columnNames[i], row.ItemArray[i].ToString());
                                    }
                                }
                            }

                            if (rowIndex != 0 && rowData.Count == 0)
                            {
                                break;
                            }

                            if (rowIndex != 0 && rowData.Count != 0)
                            {
                                rowList.Add(rowData);
                            }

                            rowIndex++;
                        }

                        sheetData.Add(sheet.TableName, rowList);
                        PrintResultText(element, string.Format("... [{0}] sheet {1} rows coverted.", sheet.TableName, rowIndex));
                    }

                    PrintResultText(element, filePath);
                    outputPath += string.Format("{0}.json", filePath.Substring(filePath.LastIndexOf('\\'), filePath.Length - filePath.LastIndexOf('\\')));
                    using (var writer = new System.IO.StreamWriter(outputPath))
                    {
                        writer.Write(Newtonsoft.Json.JsonConvert.SerializeObject(sheetData, Newtonsoft.Json.Formatting.Indented).Replace(@"\\n", @"\n"));
                    }

                    PrintResultText(element, string.Format("변환 완료. {0}", outputPath));
                }
            }
        }

        private void SaveConfigFile()
        {
            using (var writer = new System.IO.StreamWriter(Program.ConfigFilePath))
            {
                writer.Write(Newtonsoft.Json.JsonConvert.SerializeObject(Program.Config, Newtonsoft.Json.Formatting.Indented));
            }
        }

        private void PrintResultText(System.Windows.Forms.RichTextBox element, string text)
        {
            AppendResultText(element, text, System.Drawing.Color.Black);
        }

        private void ErrorResultText(System.Windows.Forms.RichTextBox element, string text)
        {
            AppendResultText(element, text, System.Drawing.Color.Red);
        }

        private void AppendResultText(System.Windows.Forms.RichTextBox element, string text, System.Drawing.Color color)
        {
            element.SelectionColor = color;
            element.Select(element.Text.Length, 0);
            if (element.Text == string.Empty)
            {
                element.SelectedText = text;
            }
            else
            {
                element.SelectedText = element.SelectedText + System.Environment.NewLine + text;
            }

            element.ScrollToCaret();
        }

        #endregion

    }
}