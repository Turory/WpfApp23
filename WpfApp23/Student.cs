using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Windows.Controls;

namespace WpfApp23
{
    internal class Student : IDataErrorInfo
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public int Age { get; set; }
        public string Course { get; set; }
        public bool IsAgreed { get; set; }

        public string Error => null;
        public bool IsValid { get; set; }

        public string this[string columnName]
        {
            get
            {
                if (columnName == nameof(Name))
                {
                    if (string.IsNullOrWhiteSpace(Name))
                        return "ФИО не может быть пустым!";

                    else if (Name.Trim().Split(' ').Length < 3)
                        return "ФИО должно состоять из трёх слов!";
                }
                    

                if (columnName == nameof(Group))
                {
                    if (string.IsNullOrWhiteSpace(Group))
                        return "Группа не должна быть пустой";

                    else if (!Group.All(char.IsLetterOrDigit))
                        return "Группа должна содержать только буквы и цифры";
                }

                if (columnName == nameof(Age) && (Age < 16 || Age > 70))
                    return "Возраст должен быть от 16 до 70";

                if (columnName == nameof(Course) && string.IsNullOrWhiteSpace(Course))
                    return "Выберите курс";

                if (columnName == nameof(IsAgreed) && !IsAgreed)
                    return "Вы должны принять условия соглашения!";

                else IsValid = true;
                return null;
            }
        }
    }
}
