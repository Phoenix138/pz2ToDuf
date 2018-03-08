using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoserToDazShapesExporter
{
    public class Pz2ToDufConverter
    {

        public class KeyValue
        {
            public KeyValue(string _key, string _value)
            {
                this.Key = _key.Replace(" ", "%20");

                this.Value = _value;
            }

            public string Key { get; set; }
            public string Value { get; set; }
            public override string ToString()
            {
                return this.Key + ": " + this.Value;
            }

            public bool HasNonZeroValue()
            {
                return this.Value != "0.0";

            }

            internal bool IsValidOutput()
            {
                return true;
            }
        }

        public void Convert(string _pz2FilePath)
        {
            const string valueParm = "valueParm";
         
            const string actor = "actor";
            Regex keyRegex = new Regex(@"k\s+\d+");

            List<KeyValue> keyValues = new List<KeyValue>();
            using (StreamReader sr = File.OpenText(_pz2FilePath))
            {
                string currentValueParm = string.Empty;
                string currentKey = string.Empty;                
                string line = string.Empty;
                bool isBodyActor = true;
                while (isBodyActor && (line = sr.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (line.StartsWith(actor))
                    {
                        if (!line.Contains("BODY"))
                        {
                            isBodyActor = false;
                        }
                    }
                    else if (line.StartsWith(valueParm))
                    {
                        currentValueParm = line.Substring(valueParm.Length).Trim();
                    }
                    else if (keyRegex.IsMatch(line))
                    {
                        var match = keyRegex.Match(line);
                        currentKey = line.Substring(match.Length).Trim();
                        keyValues.Add(new KeyValue(currentValueParm, currentKey));
        
                    }
                    
                }
            }
            
            //List<KeyValue> nonZeroKeyValues = new List<KeyValue>();

            //foreach (var kv in keyValues)
            //{
            //    if (kv.HasNonZeroValue())
            //    {
            //        nonZeroKeyValues.Add(kv);
            //    }

            //}

            ExportDuf(keyValues);
        }

        private void ExportDuf(List<KeyValue> _nonZeroKeyValues)
        {
            StringBuilder sb = new StringBuilder();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "DSON user file|*.duf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                sb.AppendLine("{");
                sb.AppendLine("     \"file_version\" : \"0.6.0.0\",");
                sb.AppendLine("     \"asset_info\" : {");
                    sb.Append("		\"id\" : \"");
                sb.Append(System.IO.Path.GetFileName(saveFileDialog.FileName));
                sb.Append("\",");
                sb.AppendLine("");
                sb.AppendLine("     \"type\" : \"preset_shape\",");
                sb.AppendLine("     \"revision\" : \"1.0\"");
                sb.AppendLine("     },");

                sb.AppendLine("      \"scene\" : {");
                sb.AppendLine("            \"animations\" : [");

                bool isFirst = true;
                foreach (var kv in _nonZeroKeyValues)
                {
                    if (kv.IsValidOutput())
                    {
                        if (isFirst)
                        {
                            isFirst = false;                                                       
                        }
                        else
                        {
                            sb.Append(",");
                            sb.AppendLine("");
                        }

                        sb.AppendLine("            {");
                        sb.Append("                \"url\" : \"name://@selection#");
                        sb.Append(kv.Key);
                        sb.Append(":?value/value\",");
                        sb.AppendLine("");
                        sb.Append("                \"keys\" : [ [ 0, ");
                        sb.Append(kv.Value);
                        sb.Append(" ] ]");
                        sb.AppendLine("");
                        sb.AppendLine("");
                        sb.Append("            }");
                    }
                }
                sb.AppendLine("");
                sb.AppendLine("        ]");
                sb.AppendLine("    }");
                sb.AppendLine("}");

                System.IO.File.WriteAllText(saveFileDialog.FileName, sb.ToString());

                MessageBox.Show("pz2 converted", "Conversion Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
    }
}
