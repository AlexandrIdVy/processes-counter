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
using System.Globalization;

namespace FindProcess
{
    
    public partial class Form1 : Form
    {        
        string pathAllCountProcess = "AllCountProcess.txt"; // файл кол-во процессов всего
        string pathCountProcess = "CountProcess.txt"; // файл кол-во процессов до профилактики
        string pathCountProcessLog = "CountProcessLog.txt"; // файл логов (дата, кол-во процессов)
        string pathSearchText = "SearchProcess.txt"; // файл с ключевыми фразами для поиска процессов
        string pathMaxProcess = "MaxProcess.txt"; // файл максимальное кол-во процессов всего
        string pathErrorsFind = "ErrorsFind.txt"; // файл ошибок поиска последнего лога Alarms.log
        string pathInfoProgramm = "InfoProgramm.txt"; // файл с данными названия и стратовой позиции программы        

        ClassLastFolder _lastFolder = new ClassLastFolder();
        ClassCheckCount _checkCount = new ClassCheckCount();
        ClassCountProcess _countProcess = new ClassCountProcess();
        ClassCountProcessToClean _countProcessToClean = new ClassCountProcessToClean();

        public Form1()
        {
            InitializeComponent();

            string[] info = File.ReadAllLines(pathInfoProgramm, Encoding.UTF8);           
            Location = new System.Drawing.Point(Convert.ToInt32(info[1]), Convert.ToInt32(info[2]));
            groupBox1.Text = info[0];
        }         
        
        // функция индикации до профилактики
        public void Indication()
        {
            if (Convert.ToInt32(ProcToClean.Text) <= 0)
            {
                timer1.Enabled = true;
                timer1.Start();
            }
            else if (Convert.ToInt32(ProcToClean.Text) > 0 && Convert.ToInt32(ProcToClean.Text) <= 5)
            {
                ProcToClean.BackColor = Color.Yellow;                
            }
            else
            {
                ProcToClean.BackColor = Color.Transparent;
            }
        }
        // окно для редактирования кол-ва процессов до профилактики
        public void ShowMyDialogBox()
        {
            Form2 testDialog = new Form2();
            testDialog.button1.DialogResult = DialogResult.OK;
            testDialog.button2.DialogResult = DialogResult.Cancel;
            testDialog.textBox1.Text = ProcToClean.Text;

            if (testDialog.ShowDialog(this) == DialogResult.OK)
            {                  
                File.WriteAllText(pathCountProcess, testDialog.textBox1.Text);
                ProcToClean.Text = File.ReadAllLines(pathCountProcess, Encoding.UTF8).First();
                ButtonChangeProc.Visible = false;
                ButtonCleanProc.Visible = false;
                ButtonCancel.Visible = false;
                ProcToClean.Visible = true;                
                Indication();
            }
            else
            {
                testDialog.textBox1.Text = ProcToClean.Text;
            }            
            testDialog.Dispose();
        }       
        // перемещения формы
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int count = 0; // переменная для подсчета количества процессов
            int checkOut; // переменная для выода количества процессов, если оно обновилось            

            string maxProc = File.ReadAllLines(pathMaxProcess, Encoding.UTF8).First();
            string[] keyTime = File.ReadAllLines(pathInfoProgramm, Encoding.UTF8);
            string[] searchText = File.ReadAllLines(pathSearchText, Encoding.UTF8); // названия техпроцессов для поиска
            string path = File.ReadAllLines(pathCountProcessLog, Encoding.UTF8).First(); // путь до корневой папки с логами
            string date = _lastFolder.LastFolder(path); // получаем название последней созданной корневой папки           
            string[] pathToDirectoris = Directory.GetDirectories(path + date + @"\"); // получаем все подпапки            

            TimeSpan time;
            TimeSpan timeKey = TimeSpan.ParseExact(keyTime[3], "g", CultureInfo.InvariantCulture);

            List<string> pathList = new List<string>(); // для записи путей к файлам во всех подпапках
            List<string> countList = new List<string>(); // для записей строк "загружен" со всех файлов в массив
            List<TimeSpan> countTime = new List<TimeSpan>(); // для записи времени запусков процессов, чтобы обросить ошибочные запуски

            // ищем файл Alarms.log во всех подпапках
            foreach (string dir in pathToDirectoris)
            {
                string pathFull = dir + @"\Alarms.log";
                pathList.Add(pathFull);                
            }

            string[] arrPath = pathList.ToArray<string>(); // записываем пути к файлам Alarms.log во всех подпапках в массив          

            // ищем во всех файлах Alarms.log строки с загрузкой процессов
            foreach (string ph in arrPath)
            {
                // если файл существует
                if (File.Exists(ph))
                {
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    string[] arr = File.ReadAllLines(ph, Encoding.GetEncoding("Windows-1251"));

                    // ищем слово "загружен" в строках
                    foreach (string a in arr.Where(s => s.Contains("загружен")))
                    {                        
                        // если строка не существует, то записываем ее
                        if (!countList.Contains(a))
                        {
                            countList.Add(a);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Файл журнала за последнюю дату не найден!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    File.AppendAllText(pathErrorsFind, string.Format(ph + Environment.NewLine));
                }
            }
            
            string[] arrCount = countList.ToArray<string>(); // записываем полученные строки со словом "заружен" в массив            

            // ищем запуски техпроцессов
            foreach (string k in searchText)
            {
                foreach (string i in arrCount.Where(s => s.Contains(k)))
                {
                    string[] subsSearch = i.Split(';');

                    time = TimeSpan.ParseExact(subsSearch[0], "g", CultureInfo.InvariantCulture);

                    if (countTime.Any())
                    {
                        if (time - countTime.Last() > timeKey)
                        {
                            //File.AppendAllText(path124, string.Format(countTime.Last() + ";" + time + ";" + (time - countTime.Last()) + Environment.NewLine));
                            count++; // считаем количество полученных строк
                        }                        
                        countTime.Add(time);
                    }
                    else
                    {
                        count++;
                        countTime.Add(time);
                    }
                    //File.AppendAllText(path123, string.Format(i + Environment.NewLine));                    
                }
            }
            
            checkOut = _checkCount.CheckCount(pathCountProcessLog, (date + ";" + Convert.ToString(count))); // получаем информацию о количестве процессов
            /// если запись о кол-ве процессов совпадает в файле, то проверяем кол-во процессов
            // обновляем данные о количестве процессов, если за текущуюю дату их стало больше
            if (checkOut == 0 || checkOut < 111)
            {                
                count -= checkOut;
                ProcToClean.Text = _countProcessToClean.CountProcessToClean(pathCountProcess, count);
                ProcMade.Text = _countProcess.CountProcess(pathAllCountProcess, count);
            }  
            else if (checkOut == 111) // если за текущую дату процессов нет, то прибавляем кол-во процессов
            {
                ProcToClean.Text = _countProcessToClean.CountProcessToClean(pathCountProcess, count);
                ProcMade.Text = _countProcess.CountProcess(pathAllCountProcess, count);
            }
           
            // если и дата и кол-во процессов совпадают, то просто выводим информацию о текущем кол-ве процессов
            ProcToClean.Text = File.ReadAllLines(pathCountProcess, Encoding.UTF8).First();
            ProcMade.Text = File.ReadAllLines(pathAllCountProcess, Encoding.UTF8).First();

            if (Convert.ToInt32(maxProc) == 25)
            {
                radioButFSS.Checked = true;
            }
            else if (Convert.ToInt32(maxProc) == 15)
            {
                radioButBFSS.Checked = true;
            }


            Indication();           
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ProcToClean.Text) <= 0)
            {
                if (ProcToClean.BackColor == Color.Transparent)
                {
                    ProcToClean.BackColor = Color.Red;
                }
                else
                {
                    ProcToClean.BackColor = Color.Transparent;
                }
            }       
        }

        private void ProcToClean_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            timer1.Stop();
            timer1.Enabled = false;
            ButtonChangeProc.Visible = true;
            ButtonCleanProc.Visible = true;
            ButtonCancel.Visible = true;
            ProcToClean.Visible = false;
            ProcToClean.BackColor = Color.Transparent;
        }

        private void ButtonCleanProc_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Enabled = false;
            File.WriteAllText(pathCountProcess, File.ReadAllLines(pathMaxProcess, Encoding.UTF8).First());
            ProcToClean.Text = File.ReadAllLines(pathCountProcess, Encoding.UTF8).First();            
            ButtonChangeProc.Visible = false;
            ButtonCleanProc.Visible = false;
            ButtonCancel.Visible = false;
            ProcToClean.Visible = true;
        }

        private void ButtonChangeProc_Click(object sender, EventArgs e)
        {            
            ShowMyDialogBox();           
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            ButtonChangeProc.Visible = false;
            ButtonCleanProc.Visible = false;
            ButtonCancel.Visible = false;
            ProcToClean.Visible = true;
            Indication();
        }

        private void RadioButFSS_CheckedChanged(object sender, EventArgs e)
        {
            File.WriteAllText(pathMaxProcess, "25");
        }

        private void RadioButBFSS_CheckedChanged(object sender, EventArgs e)
        {
            File.WriteAllText(pathMaxProcess, "15");
        }
    }
}
