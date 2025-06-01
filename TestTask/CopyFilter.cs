using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public class CopyFilter
    {
        private readonly List<string> _domenList =
        [
            "tbank.ru",
            "alfa.com",
            "vtb.ru"
        ];

        private readonly List<string> _exeptionList =
        [
            "i.ivanov@tbank.ru",
            "s.sergeev@alfa.com",
            "a.andreev@alfa.com"
        ];

        private readonly List<string> _listToSubstitute =
        [
            "t.tbankovich@tbank.ru",
            "v.veronickovna@tbank.ru",
            "v.vladislavovich@alfa.com",
            "a.aleksandrov@vtb.ru"
        ];

        /// <summary>
        /// Фильтрует поле __Copy__
        /// </summary>
        /// <param name="to">Список адрессов кому письмо предназначена</param>
        /// <param name="copys">Список адрессов кому отправить копии письма</param>
        /// <returns>Отфильтрованное поле __Copy__</returns>
        public List<string> Filter(List<string> to, List<string> copys)
        {
            if (to == null ||  copys == null)
                return [];

            //Создаем общий список адресов
            List<string> emails = [];
            emails.AddRange(to);
            emails.AddRange(copys);

            //Получаем список адресов с подходящими под бизнес задачу доменами
            var emailsWithCorrectDomens = emails.Where(x => IsСorrectDomen(x));

            //Если нужных доменов не нашлось, возращаем без изменений
            if (!emailsWithCorrectDomens.Any())
                return copys;

            //Ищем исключения
            var exeptions = GetExeptions(emails);

            //Если исключений нет, дабовляем нужные адреса в поле __Copy__
            if (exeptions.Count == 0)
            {
                foreach (var email in emailsWithCorrectDomens)
                {
                    copys.AddRange(_listToSubstitute.Where(x => GetDomen(x) == GetDomen(email) && !copys.Contains(x)));
                    return copys;
                }
            }

            //Удаляем исключения
            foreach (var listToSubstitute in _listToSubstitute)
            {
                if (copys.Contains(listToSubstitute) && exeptions.FirstOrDefault(x => GetDomen(x) == GetDomen(listToSubstitute)) != string.Empty)
                    copys.Remove(listToSubstitute);
            }

            return copys;
        }

        /// <summary>
        /// Возращает доменную чать адресса
        /// </summary>
        /// <param name="email">жлектронный адресс</param>
        /// <returns>Доменная чатсь адреса</returns>
        private static string GetDomen(string email)
        {
            ArgumentNullException.ThrowIfNull(email);

            int atIndex = email.IndexOf('@');

            string result = "";

            if (atIndex < email.Length -1)
            {
                result = email.Remove(0, atIndex + 1);
            }

            return result;
        }

        /// <summary>
        /// Проверяет подходит ли домен адресса под условия бизнеса
        /// </summary>
        /// <param name="email">Адресс, который нужно проверить</param>
        /// <returns>true, если подходит, иначе false</returns>
        private bool IsСorrectDomen(string email)
        {
            var emailDomen = GetDomen(email);
            foreach (string domen in _domenList)
            {
                if (domen == emailDomen)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Проверяет исключение этот адрес или нет
        /// </summary>
        /// <param name="email">Адрес, который нужно проверить</param>
        /// <returns>true, если икслючение, иначе false</returns>
        private bool IsException(string email)
        {
            foreach (string exeptionEmail in _exeptionList)
            {
                if (email == exeptionEmail)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Возвращает список исключений
        /// </summary>
        /// <param name="emails">Список адрессов, где нужно найти исключения</param>
        /// <returns>Список адрессов, которые подходят под параметры исключения</returns>
        private List<string> GetExeptions(List<string> emails)
        {
            var result = new List<string>();

            foreach (string email in emails)
            {
                if (IsException(email))
                    result.Add(email);
            }

            return result;
        }
    }
}
