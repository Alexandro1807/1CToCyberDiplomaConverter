using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _1CToCyberDiplomaConverter
{
    [XmlRoot(ElementName = "КурсоваяРабота")]
    public class CourseWork
    {
        [XmlElement(ElementName = "Наименование")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Оценка")]
        public int Mark { get; set; }
    }

    [XmlRoot(ElementName = "Курсовые")]
    public class CourseWorks
    {
        [XmlElement(ElementName = "КурсоваяРабота")]
        public List<CourseWork> CourseWork { get; set; }
    }

    [XmlRoot(ElementName = "Практика")]
    public class Practice
    {
        [XmlElement(ElementName = "Наименование")]
        public string Name { get; set; }

        [XmlElement(ElementName = "ЗачЕд")]
        public double CreditUnits { get; set; }

        [XmlElement(ElementName = "ЧасНед")]
        public double WeekHours { get; set; }

        [XmlElement(ElementName = "Оценка")]
        public int Mark { get; set; }
    }

    [XmlRoot(ElementName = "Заголовок")]
    public class PracticeHeader
    {
        [XmlElement(ElementName = "Наименование")]
        public string Name { get; set; }

        [XmlElement(ElementName = "ЗачЕд")]
        public int CreditUnits { get; set; }

        [XmlElement(ElementName = "ЧасНед")]
        public int WeekHours { get; set; }
    }

    [XmlRoot(ElementName = "Практики")]
    public class Practices
    {
        [XmlElement(ElementName = "Заголовок")]
        public PracticeHeader PracticeHeader { get; set; }

        [XmlElement(ElementName = "Практика")]
        public List<Practice> Practice { get; set; }
    }

    [XmlRoot(ElementName = "Госэкзамен")]
    public class StateExam
    {
        [XmlElement(ElementName = "Наименование")]
        public string Name { get; set; }

        [XmlElement(ElementName = "ЗачЕд")]
        public int CreditUnits { get; set; }

        [XmlElement(ElementName = "ЧасНед")]
        public int WeekHours { get; set; }

        [XmlElement(ElementName = "Оценка")]
        public int Mark { get; set; }
    }

    [XmlRoot(ElementName = "Заголовок")]
    public class StateExamHeader
    {
        [XmlElement(ElementName = "Наименование")]
        public string Name { get; set; }

        [XmlElement(ElementName = "ЗачЕд")]
        public int CreditUnits { get; set; }

        [XmlElement(ElementName = "ЧасНед")]
        public int WeekHours { get; set; }
    }

    [XmlRoot(ElementName = "Госэкзамены")]
    public class StateExams
    {
        [XmlElement(ElementName = "Заголовок")]
        public StateExamHeader StateExamHeader { get; set; }

        [XmlElement(ElementName = "Госэкзамен")]
        public List<StateExam> StateExam { get; set; }
    }

    [XmlRoot(ElementName = "Дисциплина")]
    public class Discipline
    {
        [XmlElement(ElementName = "Наименование")]
        public string Name { get; set; }

        [XmlElement(ElementName = "ЗачЕд")]
        public int CreditUnits { get; set; }

        [XmlElement(ElementName = "ЧасНед")]
        public int WeekHours { get; set; }

        [XmlElement(ElementName = "Оценка")]
        public int Mark { get; set; }
    }

    [XmlRoot(ElementName = "Дисциплины")]
    public class Disciplines
    {
        [XmlElement(ElementName = "Дисциплина")]
        public List<Discipline> Discipline { get; set; }
    }

    [XmlRoot(ElementName = "ОбъемОбрПрограммы")]
    public class EduProgramVolume
    {
        [XmlElement(ElementName = "Наименование")]
        public string Name { get; set; }

        [XmlElement(ElementName = "ЗачЕд")]
        public int CreditUnits { get; set; }

        [XmlElement(ElementName = "ЧасНед")]
        public int WeekHours { get; set; }
    }

    [XmlRoot(ElementName = "ОбъемАудиторныхЧасов")]
    public class ClassroomHoursVolume
    {
        [XmlElement(ElementName = "Наименование")]
        public string Name { get; set; }

        [XmlElement(ElementName = "ЗачЕд")]
        public int CreditUnits { get; set; }

        [XmlElement(ElementName = "ЧасНед")]
        public int WeekHours { get; set; }
    }

    [XmlRoot(ElementName = "Факультатив")]
    public class Elective
    {
        [XmlElement(ElementName = "Наименование")]
        public string Name { get; set; }

        [XmlElement(ElementName = "ЗачЕд")]
        public int CreditUnits { get; set; }

        [XmlElement(ElementName = "ЧасНед")]
        public int WeekHours { get; set; }

        [XmlElement(ElementName = "Оценка")]
        public int Mark { get; set; }
    }

    [XmlRoot(ElementName = "Факультативы")]
    public class Electives
    {
        [XmlElement(ElementName = "Факультатив")]
        public List<Elective> Elective { get; set; }
    }

    [XmlRoot(ElementName = "ДополнительныеСведения")]
    public class AdditionalInfo
    {
        [XmlElement(ElementName = "ДопСвед")]
        public List<string> AddInfo { get; set; }
    }

    [XmlRoot(ElementName = "Студент")]
    public class Student
    {
        [XmlElement(ElementName = "Фамилия")]
        public string LastName { get; set; }

        [XmlElement(ElementName = "Имя")]
        public string FirstName { get; set; }

        [XmlElement(ElementName = "Отчество")]
        public string MiddleName { get; set; }

        [XmlElement(ElementName = "ДатаРожд")]
        public string Birthday { get; set; }

        [XmlElement(ElementName = "СНИЛС")]
        public string SNILS { get; set; }

        [XmlElement(ElementName = "ОКСМ")]
        public string OKSM { get; set; }

        [XmlElement(ElementName = "МестоРожд")]
        public string Birthplace { get; set; }

        [XmlElement(ElementName = "НаименованиеДокПредОбр")]
        public string NameDocPrevEducation { get; set; }

        [XmlElement(ElementName = "ГодДокПредОбр")]
        public int YearDocPrevEducation { get; set; }

        [XmlElement(ElementName = "СерияДокПредОбр")]
        public int SerialDocPrevEducation { get; set; }

        [XmlElement(ElementName = "НомерДокПредОбр")]
        public int NumberDocPrevEducation { get; set; }

        [XmlElement(ElementName = "ДатаРешенияГэк")]
        public string DateDecisionSEC { get; set; }

        [XmlElement(ElementName = "НомерПротоколаГэк")]
        public string NumberOfProtocolSEC { get; set; }

        [XmlElement(ElementName = "ПредседательГэк")]
        public string ChairmanSEC { get; set; }

        [XmlElement(ElementName = "Квалификация")]
        public string Qualification { get; set; }

        [XmlElement(ElementName = "ПериодОбученияС")]
        public string StudyPeriodOn { get; set; }

        [XmlElement(ElementName = "ПериодОбученияПо")]
        public string StudyPeriodOff { get; set; }

        [XmlElement(ElementName = "СрокОбучения")]
        public string StudyPeriod { get; set; }

        [XmlElement(ElementName = "НаименованиеСпец")]
        public string SpecialityName { get; set; }

        [XmlElement(ElementName = "КодСпец")]
        public string SpecialityCode { get; set; }

        [XmlElement(ElementName = "Курсовые")]
        public CourseWorks CourseWorks { get; set; }

        [XmlElement(ElementName = "Практики")]
        public Practices Practices { get; set; }

        [XmlElement(ElementName = "Госэкзамены")]
        public StateExams StateExams { get; set; }

        [XmlElement(ElementName = "Дисциплины")]
        public Disciplines Disciplines { get; set; }

        [XmlElement(ElementName = "ОбъемОбрПрограммы")]
        public EduProgramVolume EduProgramVolume { get; set; }

        [XmlElement(ElementName = "ОбъемАудиторныхЧасов")]
        public ClassroomHoursVolume ClassroomHoursVolume { get; set; }

        [XmlElement(ElementName = "Факультативы")]
        public Electives Electives { get; set; }

        [XmlElement(ElementName = "ДополнительныеСведения")]
        public AdditionalInfo AdditionalInfo { get; set; }
    }

    [XmlRoot(ElementName = "Студенты")]
    public class Students
    {
        [XmlElement(ElementName = "Студент")]
        public List<Student> Student { get; set; }
    }

    [Serializable]
    [XmlRoot(ElementName = "ФайлОбменаКиберДиплом")]
    public class AttestationCyberDiplomViewModel
    {
        [XmlElement(ElementName = "Студенты")]
        public Students Students { get; set; }

        [XmlAttribute(AttributeName = "Версия")]
        public string Version { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}
