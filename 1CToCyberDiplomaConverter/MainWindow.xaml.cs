using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System;

namespace _1CToCyberDiplomaConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, int> mapMarks = new Dictionary<string, int>()
        {
            ["-"] = 0,
            ["Не зачтено"] = 1,
            ["Другая дисциплина"] = 1,
            ["Не явился"] = 1,
            ["Неудовлетворительно"] = 2,
            ["Удовлетворительно"] = 3,
            ["Хорошо"] = 4,
            ["Отлично"] = 5,
            ["Зачтено"] = 6,
            ["Перезачтено"] = 7,
            ["Переаттестация"] = 8
        };

        public MainWindow()
        {
            InitializeComponent();
            InitializeFormToEndState();
        }

        private void InitializeFormToEndState()
        {
            int year = DateTime.Now.Year;
            TextBoxHoursPractice.Text = "36";
            TextBoxHoursSEC.Text = "3";
            TextBoxHoursContact.Text = "6000";
            TextBoxDateDecisionSEC.Text = string.Format("03.07.{0}", year);
            TextBoxChairmanSEC.Text = "Фамилия Имя Отчество";
            TextBoxYearDocPrevEducation.Text = string.Format("{0}", year - 6);
            TextBoxQualification.Text = "Врач - лечебник";
            TextBoxSpecialityCode.Text = "31.05.01";
            TextBoxValueEduProgram.Text = "300";
            ComboBoxHoursContactType.ItemsSource = new List<string>() { "в том числе объем контактной работы обучающихся во взаимодействии с преподавателем в академических часах:", "в том числе объем контактной работы обучающихся во взаимодействии с преподавателем в астрономических часах:", "в том числе аудиторных часов:", "в том числе часов:" };
            ComboBoxStudyPeriod.ItemsSource = new List<string>() { "2 года", "3 года", "4 года", "5 лет", "5 лет 6 месяцев", "6 лет" };
            ComboBoxSpecialityName.ItemsSource = new List<string>() { "Клиническая психология", "Лечебное дело", "Медико-профилактическое дело", "Общественное здоровье", "Педиатрия", "Сестринское дело", "Стоматология", "Фармация" };
            ComboBoxFormOfEducation.ItemsSource = new List<string>() { "Заочная", "Очная", "Очно-заочная" };
            ComboBoxSpecialization.ItemsSource = new List<string>() { "отсутствует", "Патопсихологическая диагностика и психотерапия" };
            ComboBoxStudyPeriod.SelectedValue = "6 лет";
            ComboBoxSpecialityName.SelectedValue = "Лечебное дело";
            ComboBoxFormOfEducation.SelectedValue = "Очная";
            ComboBoxSpecialization.SelectedValue = "отсутствует";
        }

        private void ButtonAddCSVFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new() { AddExtension = true, DefaultExt = ".csv", Filter = "CSV (.csv)|*.csv" };
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                LabelCSVFilePath.Content = "Путь: " + dialog.FileName;
                LabelCSVFilePath.Visibility = Visibility.Visible;
            }
        }

        private void TextBoxHoursPractice_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            AdditionalFunctions.NumberPreviewKeyDown(sender, e);
        }

        private void TextBoxHoursPractice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            AdditionalFunctions.NumberPreviewTextInput(sender, e);
        }

        private void TextBoxHoursSEC_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            AdditionalFunctions.NumberPreviewKeyDown(sender, e);
        }

        private void TextBoxHoursSEC_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            AdditionalFunctions.NumberPreviewTextInput(sender, e);
        }

        private void TextBoxHoursContact_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            AdditionalFunctions.NumberPreviewKeyDown(sender, e);
        }

        private void TextBoxHoursContact_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            AdditionalFunctions.NumberPreviewTextInput(sender, e);
        }

        private void TextBoxSpecialityCode_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TextBoxSpecialityCode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void TextBoxYearDocPrevEducation_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TextBoxYearDocPrevEducation_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void TextBoxValueEduProgram_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            AdditionalFunctions.NumberPreviewKeyDown(sender, e);
        }

        private void TextBoxValueEduProgram_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            AdditionalFunctions.NumberPreviewTextInput(sender, e);
        }

        private void TextBoxQualification_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            AdditionalFunctions.TextPreviewKeyDown(sender, e);
        }

        private void TextBoxDateDecisionSEC_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TextBoxDateDecisionSEC_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void TextBoxChairmanSEC_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TextBoxChairmanSEC_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            Convert();
        }

        private void Convert()
        {
            if (!int.TryParse(TextBoxYearDocPrevEducation.Text, out int yearDocPrevEducation)) yearDocPrevEducation = 0;
            if (!int.TryParse(TextBoxHoursPractice.Text, out int hoursPractice)) hoursPractice = 0;
            if (!int.TryParse(TextBoxHoursSEC.Text, out int hoursSEC)) hoursSEC = 0;
            if (!int.TryParse(TextBoxHoursContact.Text, out int hoursContact)) hoursContact = 0;
            if (!int.TryParse(TextBoxValueEduProgram.Text, out int valueEduProram)) valueEduProram = 0;
            string qualification = TextBoxQualification.Text;
            string hoursContactType = ComboBoxHoursContactType.Text;
            string chairmanSEC = TextBoxChairmanSEC.Text;
            string studyPeriod = ComboBoxStudyPeriod.Text;
            string specialityCode = TextBoxSpecialityCode.Text;
            string specialityName = ComboBoxSpecialityName.Text;
            string formOfEducation = ComboBoxFormOfEducation.Text;
            string specialization = ComboBoxSpecialization.Text;
            if (!DateTime.TryParse(TextBoxDateDecisionSEC.Text, out DateTime dateDecisionSEC)) dateDecisionSEC = DateTime.Now;

            List<string> dataList = new List<string>();
            string path = ((string)LabelCSVFilePath.Content).Replace("Путь: ", "");
            if (path == "")
            {
                LabelState.Content = "Ошибка. Файл отсутствует.";
                return;
            }
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding win1251 = Encoding.GetEncoding("windows-1251");
            string[] lines = File.ReadAllLines(path, win1251);
            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line) || string.IsNullOrWhiteSpace(line)) continue;
                dataList.Add(line);
            }
            if (dataList.Count <= 0)
            {
                this.LabelState.Visibility = Visibility.Visible;
                LabelState.Content = "Ошибка. Файл не распознался, либо он пуст.";
                return;
            }
            //Проверка файла CSV
            string[] header = dataList[0].Replace("\"\"\"", "><").Replace("\"\"", "><").Replace("\"", "").Replace("><", "\"").Split(';');
            string headerMain = "ФИО;Фамилия;Имя;Отчество;Дата рождения;СНИЛС;Тип документа образования;Гражданство;Дата начала действия приказа на зачисление;Дата окончания обучения;Дисциплина;Индекс дисциплины;Нагрузка по дисциплине (в часах);Оценка (успеваемость)";
            string headerCheck = string.Join(";", header[0], header[1], header[2], header[3], header[4], header[5], header[6], header[7], header[8], header[9], header[10], header[11], header[12], header[13]);
            if (headerMain != headerCheck)
            {
                this.LabelState.Visibility = Visibility.Visible;
                LabelState.Content = "Ошибка. Файл не содержит верную структуру колонок.";
                return;
            }
            this.LabelState.Visibility = Visibility.Hidden;

            AttestationCyberDiplomViewModel diploma = new AttestationCyberDiplomViewModel();
            List<Student> dictionary = new List<Student>();
            List<Tuple<Student, string, Discipline, Practice, CourseWork, Elective>> tuples = new List<Tuple<Student, string, Discipline, Practice, CourseWork, Elective>>();
            List<string> addInfos = new List<string>() { specialization, formOfEducation };
            bool isFirstRow = true, isIndexCheck = (bool)CheckBoxIndexCheck.IsChecked;
            dataList.ForEach(u =>
            {
                if (isFirstRow)
                {
                    isFirstRow = false;
                    return;
                }
                string[] user = u.Replace("\"\"\"", "><").Replace("\"\"", "><").Replace("\"", "").Replace("><", "\"").Split(';');
                //Распределение данных строки по переменным
                //Фамилия
                string lastName = user[1];
                //Имя
                string firstName = user[2];
                //Отчество
                string middleName = user[3];
                //Дата рождения
                DateTime birthday = user[4] != "" ? DateTime.Parse(user[4]) : DateTime.Now;
                //СНИЛС
                string SNILS = user[5];
                //Наименование документа о предыдущем образовании
                string nameDocPrevEducation = user[6];
                //Гражданство (потенциальное ОКСМ)
                string citizenship = user[7];
                //Дата начала действия приказа на зачисление (Начало периода)
                DateTime studyPeriodOn = user[8] != "" ? DateTime.Parse(user[8]) : DateTime.Now;
                //Дата окончания обучения
                DateTime studyPeriodOff = user[9] != "" ? DateTime.Parse(user[9]) : DateTime.Now;
                //Дисциплина
                string disciplineName = user[10];
                //Индекс дисциплины
                string index = user[11];
                //Нагрузка по дисциплине в часах
                int hours = user[12] != "" ? int.Parse(user[12].Replace(" ", "")) : 0;
                //Оценка прописью
                string mark = user[13];
                //Формирование диплома
                Student studentDiploma = dictionary.FirstOrDefault(q => q.LastName == lastName && q.FirstName == firstName && q.MiddleName == middleName);
                if (studentDiploma == null)
                {
                    Disciplines disciplines = new Disciplines() { Discipline = new List<Discipline>() };
                    CourseWorks courseWorks = new CourseWorks() { CourseWork = new List<CourseWork>() };
                    Practices practices = new Practices() { PracticeHeader = new PracticeHeader() { CreditUnits = hoursPractice, WeekHours = hoursPractice * 36 }, Practice = new List<Practice>() };
                    StateExams stateExams = new StateExams() { StateExamHeader = new StateExamHeader() { CreditUnits = hoursSEC, WeekHours = hoursSEC * 36 }, StateExam = new List<StateExam>() };
                    Electives electives = new Electives() { Elective = new List<Elective>() };
                    EduProgramVolume eduProgramVolume = new EduProgramVolume() { Name = "Объем образовательной программы", CreditUnits = valueEduProram };
                    ClassroomHoursVolume classroomHoursVolume = new ClassroomHoursVolume() { Name = hoursContactType, CreditUnits = (int)(hoursContact / 36), WeekHours = hoursContact };
                    AdditionalInfo additionalInfo = new AdditionalInfo() { AddInfo = addInfos };
                    studentDiploma = new Student()
                    {
                        LastName = lastName,
                        FirstName = firstName,
                        MiddleName = middleName,
                        Birthday = birthday.ToShortDateString(),
                        SNILS = SNILS,
                        NameDocPrevEducation = nameDocPrevEducation,
                        DateDecisionSEC = dateDecisionSEC.ToShortDateString(),
                        Qualification = qualification,
                        ChairmanSEC = chairmanSEC,
                        YearDocPrevEducation = yearDocPrevEducation,
                        StudyPeriodOn = studyPeriodOn.ToShortDateString(),
                        StudyPeriodOff = studyPeriodOff.ToShortDateString(),
                        StudyPeriod = studyPeriod,
                        SpecialityName = specialityName,
                        SpecialityCode = specialityCode,
                        Disciplines = disciplines,
                        CourseWorks = courseWorks,
                        Practices = practices,
                        StateExams = stateExams,
                        Electives = electives,
                        EduProgramVolume = eduProgramVolume,
                        ClassroomHoursVolume = classroomHoursVolume,
                        AdditionalInfo = additionalInfo
                    };
                    dictionary.Add(studentDiploma);
                }
                string disciplineType = string.Empty;
                if (index != string.Empty)
                {
                    if (index.Contains(".О.")) index = index.Replace(".О.", ".0.");
                    if (index.Contains("ФТД")) disciplineType = "Факультатив";
                    else if (index.Contains("(У)")) disciplineType = "Учебная практика";
                    else if (index.Contains("(П)")) disciplineType = "Производственная практика";
                    else if (index.Contains("ДВ")) disciplineType = "Дисциплина по выбору";
                    else disciplineType = "Дисциплина";
                    //Исправление отсутствия нуля одноразрядных чисел
                    int tempInt = index.LastIndexOf('.');
                    string tempString = index.Substring(tempInt);
                    if (tempString.Length == 2) tempString = tempString.Replace(".", ".0");
                    index = string.Format("{0}{1}", index.Remove(tempInt), tempString);
                }
                if (isIndexCheck) disciplineName = string.Format($"{index} {disciplineName}");
                //Оформление дисциплины
                Discipline discipline = new Discipline();
                Practice practice = new Practice();
                CourseWork courseWork = new CourseWork();
                StateExam stateExam = new StateExam();
                Elective elective = new Elective();
                switch (disciplineType)
                {
                    case "Дисциплина":
                    case "Дисциплина по выбору":
                        {
                            discipline = studentDiploma.Disciplines.Discipline.FirstOrDefault(q => q.Name == disciplineName);
                            if (discipline != null)
                            {
                                if (discipline.Mark != 6) return;
                                discipline.Mark = mapMarks[mark];
                            }
                            else
                            {
                                discipline = new Discipline()
                                {
                                    Name = disciplineName,
                                    Mark = mapMarks[mark],
                                    WeekHours = hours,
                                    CreditUnits = (int)(hours / 36)
                                };
                                studentDiploma.Disciplines.Discipline.Add(discipline);
                                tuples.Add(new Tuple<Student, string, Discipline, Practice, CourseWork, Elective>(studentDiploma, index, discipline, null, null, null));
                            }
                            break;
                        }
                    case "Учебная практика":
                    case "Производственная практика":
                        {
                            practice = studentDiploma.Practices.Practice.FirstOrDefault(q => q.Name == string.Format(disciplineType.ToLower() + " (" + disciplineName + ")"));
                            if (practice != null)
                            {
                                if (practice.Mark != 6) return;
                                practice.Mark = mapMarks[mark];
                            }
                            else
                            {
                                practice = new Practice()
                                {
                                    Name = string.Format(disciplineType.ToLower() + " (" + disciplineName + ")"),
                                    Mark = mapMarks[mark],
                                    WeekHours = hours,
                                    CreditUnits = (int)(hours / 36)
                                };
                                studentDiploma.Practices.Practice.Add(practice);
                                tuples.Add(new Tuple<Student, string, Discipline, Practice, CourseWork, Elective>(studentDiploma, index, null, practice, null, null));
                            }
                            break;
                        }
                    case "Курсовая работа":
                        {
                            courseWork = studentDiploma.CourseWorks.CourseWork.FirstOrDefault(q => q.Name == disciplineName);
                            if (courseWork != null)
                            {
                                if (courseWork.Mark != 6) return;
                                courseWork.Mark = mapMarks[mark];
                            }
                            else
                            {
                                courseWork = new CourseWork()
                                {
                                    Name = disciplineName,
                                    Mark = mapMarks[mark]
                                };
                                studentDiploma.CourseWorks.CourseWork.Add(courseWork);
                                tuples.Add(new Tuple<Student, string, Discipline, Practice, CourseWork, Elective>(studentDiploma, index, null, null, courseWork, null));
                            }
                            break;
                        }
                    case "Факультатив":
                        {
                            elective = studentDiploma.Electives.Elective.FirstOrDefault(q => q.Name == disciplineName);
                            if (elective != null)
                            {
                                if (elective.Mark != 6) return;
                                elective.Mark = mapMarks[mark];
                            }
                            else
                            {
                                elective = new Elective()
                                {
                                    Name = disciplineName,
                                    Mark = mapMarks[mark],
                                    WeekHours = hours,
                                    CreditUnits = (int)(hours / 36)
                                };
                                studentDiploma.Electives.Elective.Add(elective);
                                tuples.Add(new Tuple<Student, string, Discipline, Practice, CourseWork, Elective>(studentDiploma, index, null, null, null, elective));
                            }
                            break;
                        }
                }
            });
            Students students = new Students();
            diploma.Version = "3.5.1";
            diploma.Students = students;
            dictionary.ForEach(student =>
            {
                student.Disciplines.Discipline = tuples.Where(q => q.Item1 == student && q.Item3 != null).OrderBy(q => q.Item2).Select(q => q.Item3).ToList();
                student.Practices.Practice = tuples.Where(q => q.Item1 == student && q.Item4 != null).OrderBy(q => q.Item2).Select(q => q.Item4).ToList();
                student.Electives.Elective = tuples.Where(q => q.Item1 == student && q.Item6 != null).OrderBy(q => q.Item2).Select(q => q.Item6).ToList();
                student.StateExams.StateExam = new List<StateExam>() { new StateExam() { Name = "государственный экзамен", CreditUnits = hoursSEC, Mark = 0 } };
            });
            diploma.Students.Student = dictionary;

            byte[] bytes;
            string filename = string.Format("КиберДиплом.xml");
            XmlSerializer deserializer = new XmlSerializer(typeof(AttestationCyberDiplomViewModel));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            using (AdditionalFunctions.StringWriterWithEncoding sw = new AdditionalFunctions.StringWriterWithEncoding(Encoding.UTF8))
            using (XmlWriter xmlWriter = XmlWriter.Create(sw))
            {
                deserializer.Serialize(xmlWriter, diploma, namespaces);
                xmlWriter.WriteEndDocument();
                bytes = Encoding.UTF8.GetBytes(sw.ToString());
            }
            XmlDocument doc = new XmlDocument();
            string xml = Encoding.UTF8.GetString(bytes);
            doc.LoadXml(xml);
            string endPath = "C:\\CyberDiplomaFiles";
            if (!Directory.Exists(endPath)) Directory.CreateDirectory(endPath);
            doc.Save(endPath + "\\" + specialityName + ".xml");
            LabelState.Content = "Всё получилось! Ищите файл в " + endPath;
            LabelState.Visibility = Visibility.Visible;
        }
    }
}