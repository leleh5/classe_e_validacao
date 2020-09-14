using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace classe_e_validacao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("Texto");
            comboBox1.Items.Add("Número Natural");
            comboBox1.Items.Add("Número Inteiro");
            comboBox1.Items.Add("Número Decimal");
            comboBox1.Items.Add("if(...)");

            radioButton1.Checked = true;
            comboBox1.SelectedIndex = comboBox1.FindStringExact("Texto");

            textBox1.Focus();
        }

        public string ConvMaiuscula(string Input)
        {
            System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Globalization.TextInfo textInfo = cultureInfo.TextInfo;
            return textInfo.ToTitleCase(Input.ToLower());
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            Classe_e_Validacao classe_e_validacao = new Classe_e_Validacao();
            classe_e_validacao.setProp(textBox2.Text);

            Classe_e_ValidacaoBLL.validaprop(classe_e_validacao);

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMens());
                return;
            }


            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Favor preencher o campo de tipo");
            }

            else
            {
                int comp;

                string text;
                string list1 = "";


                text = ConvMaiuscula(textBox2.Text);

                for (comp = 0; comp <= (text.Length - 1); ++comp)
                {
                    if (text[comp] != ' ')
                    {
                        list1 = list1 + text[comp];
                    }

                }

                listBox1.Items.Add(list1.ToString());

                if (comboBox1.Text == "Texto")
                {
                    listBox3.Items.Add("string");
                }
                else if (comboBox1.Text == "Número Natural")
                {
                    listBox3.Items.Add("uint");
                }
                else if (comboBox1.Text == "Número Inteiro")
                {
                    listBox3.Items.Add("int");
                }
                else if (comboBox1.Text == "Número Decimal")
                {
                    listBox3.Items.Add("float");
                }

                else
                {
                    listBox3.Items.Add(textBox3.Text);
                }

                if (radioButton1.Checked)
                {
                    listBox2.Items.Add("not null");
                }
                else { listBox2.Items.Add("null"); }

                textBox2.Clear();
                comboBox1.SelectedIndex = comboBox1.FindStringExact("Texto");
                textBox2.Focus();

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int ind = listBox1.SelectedIndex;

            if (ind == -1)
            {
                MessageBox.Show("Favor selecionar a propriedade que deseja apagar.");
                return;
            }

            else
            {

                listBox1.Items.RemoveAt(ind);
                listBox2.Items.RemoveAt(ind);
                listBox3.Items.RemoveAt(ind);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Focus();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Classe_e_Validacao classe_e_validacao = new Classe_e_Validacao();

            classe_e_validacao.setClas(textBox1.Text);

            classe_e_validacao.setList_p(listBox1.Items.Count.ToString());

            Classe_e_ValidacaoBLL.validaclas(classe_e_validacao);

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMens());
                return;
            }

            Classe_e_ValidacaoBLL.validalist_p(classe_e_validacao);


            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMens());
                return;
            }

            else
            {
                string cla;
                int comp2;
                string list2 = "";

                cla = ConvMaiuscula(textBox1.Text);

                for (comp2 = 0; comp2 <= (cla.Length - 1); ++comp2)
                {
                    if (cla[comp2] != ' ')
                    {
                        list2 = list2 + cla[comp2];
                    }

                }

                FolderBrowserDialog dialog = new FolderBrowserDialog();

                string a = Application.StartupPath;

                string path = System.IO.Path.Combine(dialog.Description, list2 + ".txt");
                System.IO.File.Create(path, 1, System.IO.FileOptions.None).Close();

                string path1 = System.IO.Path.Combine(dialog.Description, "Erro.txt");
                System.IO.File.Create(path, 1, System.IO.FileOptions.None).Close();

                string path2 = System.IO.Path.Combine(dialog.Description, list2 + "BLL.txt");
                System.IO.File.Create(path2, 1, System.IO.FileOptions.None).Close();

                string text3, text4, text5;

                using (StreamWriter writer = new StreamWriter(dialog.Description + list2 + ".txt"))
                {


                    writer.WriteLine("using System;");
                    writer.WriteLine("using System.Collections.Generic;");
                    writer.WriteLine("using System.Linq;");
                    writer.WriteLine("using System.Text;");
                    writer.WriteLine("using System.Threading.Tasks;");
                    writer.WriteLine("");
                    writer.WriteLine("namespace " + list2.ToLower());
                    writer.WriteLine("{");
                    writer.WriteLine("    class " + list2);
                    writer.WriteLine("    {");

                    foreach (string Items in listBox1.Items)
                    {
                        text3 = Items;
                        writer.WriteLine("        private String " + text3.ToLower() + ";");
                    }

                    writer.WriteLine("");

                    foreach (string Items in listBox1.Items)
                    {
                        text4 = Items;
                        writer.WriteLine("        public void set" + text4 + "(String _" + text4.ToLower() + ") { " + text4.ToLower() + " = _" + text4.ToLower() + "; }");
                    }

                    writer.WriteLine("");

                    foreach (string Items in listBox1.Items)
                    {
                        text5 = Items;
                        writer.WriteLine("        public String get" + text5 + "() { return " + text5.ToLower() + "; }");
                    }


                    writer.WriteLine("");

                    writer.WriteLine("    }");
                    writer.WriteLine("}");


                }


                using (StreamWriter writer = new StreamWriter(dialog.Description + "Erro.txt"))
                {

                    writer.WriteLine("using System;");
                    writer.WriteLine("using System.Collections.Generic;");
                    writer.WriteLine("using System.Linq;");
                    writer.WriteLine("using System.Text;");
                    writer.WriteLine("using System.Threading.Tasks;");
                    writer.WriteLine("");
                    writer.WriteLine("namespace " + list2.ToLower());
                    writer.WriteLine("{");
                    writer.WriteLine("    class Erro");
                    writer.WriteLine("    {");
                    writer.WriteLine("        private static bool erro;");
                    writer.WriteLine("        private static String mens;");
                    writer.WriteLine("");
                    writer.WriteLine("        public static void setErro(bool _erro) { erro = _erro; }");
                    writer.WriteLine("        public static void setErro(String _mens) { erro = true; mens = _mens; }");
                    writer.WriteLine("        public static bool getErro() { return erro; }");
                    writer.WriteLine("        public static String getMens() { return mens; }");

                    writer.WriteLine("    }");
                    writer.WriteLine("}");


                }


                using (StreamWriter writer = new StreamWriter(dialog.Description + list2 + "BLL.txt"))
                {

                    writer.WriteLine("using System;");
                    writer.WriteLine("using System.Collections.Generic;");
                    writer.WriteLine("using System.Linq;");
                    writer.WriteLine("using System.Text;");
                    writer.WriteLine("using System.Threading.Tasks;");
                    writer.WriteLine("");
                    writer.WriteLine("namespace " + list2.ToLower());
                    writer.WriteLine("{");
                    writer.WriteLine("    class " + list2 + "BLL");
                    writer.WriteLine("    {");

                    writer.WriteLine("        public static void validadados(" + list2 + " " + list2.ToLower() + ")");
                    writer.WriteLine("        {");
                    writer.WriteLine("            Erro.setErro(false);");
                    writer.WriteLine("");

                    int cont1 = 1;

                    foreach (string Items in listBox1.Items)
                    {
                        text3 = Items;
                        int cont2 = 1;
                        foreach (string Items2 in listBox2.Items)
                        {
                            string text7 = Items2;

                            if (cont1 == cont2 && text7 == "not null")
                            {

                                writer.WriteLine("            if (" + list2.ToLower() + ".get" + text3 + "().Length == 0)");
                                writer.WriteLine("            {");
                                writer.WriteLine("                Erro.setErro('O campo é de preenchimento obrigatório...');");
                                writer.WriteLine("                return;");
                                writer.WriteLine("            }");
                                writer.WriteLine("            else { " + list2.ToLower() + ".get" + text3 + "(); }");
                                writer.WriteLine("");
                            }
                            cont2 = cont2 + 1;
                        }

                        int cont3 = 1;
                        foreach (string Items3 in listBox3.Items)
                        {
                            string text8 = Items3;

                            if (cont1 == cont3 && text8 == "uint")
                            {
                                writer.WriteLine("                try");
                                writer.WriteLine("                {");
                                writer.WriteLine("                    uint.Parse(" + list2.ToLower() + ".get" + text3 + "());");
                                writer.WriteLine("                    " + list2.ToLower() + ".get" + text3 + "();");
                                writer.WriteLine("                }");
                                writer.WriteLine("");
                                writer.WriteLine("                catch");
                                writer.WriteLine("                {");
                                writer.WriteLine("                    Erro.setErro('O campo deve ser numérico, inteiro e positivo...');");
                                writer.WriteLine("                    return;");
                                writer.WriteLine("                }");
                                writer.WriteLine("");
                            }

                            else if (cont1 == cont3 && text8 == "int")
                            {
                                writer.WriteLine("                try");
                                writer.WriteLine("                {");
                                writer.WriteLine("                    int.Parse(" + list2.ToLower() + ".get" + text3 + "());");
                                writer.WriteLine("                    " + list2.ToLower() + ".get" + text3 + "();");
                                writer.WriteLine("                }");
                                writer.WriteLine("");
                                writer.WriteLine("                catch");
                                writer.WriteLine("                {");
                                writer.WriteLine("                    Erro.setErro('O campo deve ser numérico e inteiro...');");
                                writer.WriteLine("                    return;");
                                writer.WriteLine("                }");
                                writer.WriteLine("");
                            }

                            else if (cont1 == cont3 && text8 == "float")
                            {
                                writer.WriteLine("                try");
                                writer.WriteLine("                {");
                                writer.WriteLine("                    float.Parse(" + list2.ToLower() + ".get" + text3 + "());");
                                writer.WriteLine("                    " + list2.ToLower() + ".get" + text3 + "();");
                                writer.WriteLine("                }");
                                writer.WriteLine("");
                                writer.WriteLine("                catch");
                                writer.WriteLine("                {");
                                writer.WriteLine("                    Erro.setErro('O campo deve ser numérico...');");
                                writer.WriteLine("                    return;");
                                writer.WriteLine("                }");
                                writer.WriteLine("");
                            }

                            else if (cont1 == cont3 && text8 == "string")
                            {
                            }

                            else if (cont1 == cont3)
                            {
                                string list8 = "";
                                int iden = 0, ex = 0, ex2 = 0;
                                for (iden = 0; iden <= (text8.Length - 1); ++iden)
                                {
                                    if (text8[iden] != '@' || ex == 1)
                                    {

                                        if (text8[iden] == '@')
                                        {
                                            list8 = list8 + "()";
                                            ex = 0;
                                        }
                                        else if(ex2==1)
                                        {
                                            list8 = list8 + text8[iden].ToString().ToUpper();
                                            ex2 = 0;
                                        }
                                        else
                                        {
                                            list8 = list8 + text8[iden];
                                        }
                                    }
                                    else if (ex == 0)
                                    {

                                        list8 = list8 + list2.ToLower() + ".get";
                                        ex = 1;
                                        ex2 = 1;
                                    }

                                }

                                writer.WriteLine("                if(" + list8 + ")");
                                writer.WriteLine("                {");
                                writer.WriteLine("                    " + list2.ToLower() + ".get" + text3 + "();");
                                writer.WriteLine("                }");
                                writer.WriteLine("");
                                writer.WriteLine("                else");
                                writer.WriteLine("                {");
                                writer.WriteLine("                    Erro.setErro('O campo não atende às especificações...');");
                                writer.WriteLine("                    return;");
                                writer.WriteLine("                }");
                                writer.WriteLine("");
                            }

                            cont3 = cont3 + 1;
                        }

                        cont1 = cont1 + 1;
                    }


                    writer.WriteLine("      }");

                    writer.WriteLine("    }");
                    writer.WriteLine("}");


                }


                MessageBox.Show("Classe criada com sucesso");

                listBox1.Items.Clear();
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox1.Focus();

            }
        }
    }
}
