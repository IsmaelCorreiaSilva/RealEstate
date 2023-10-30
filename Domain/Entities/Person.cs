
namespace Domain.Entities
{
    public class Person
    {
        public Person(string document, string name, DateTime dateBirth) 
        {
            Document = document;
            Name = name;
            DateBirth = dateBirth;
        }
        public string Document { get; private set; }
        public string Name { get; private set; }
        public DateTime DateBirth { get; private set; }

        public bool IsAdult()
        {
            return (DateTime.Today.Year - this.DateBirth.Year) >= 18;
        }
        public bool DocumentIsValid() 
        {
            var multiplier1 = new int[9] {10,9,8,7,6,5,4,3,2};
            var multiplier2 = new int[10] {11,10,9,8,7,6,5,4,3,2 };
            string documentTemp;
            string digit;
            int sum;
            int rest;


            Document = Document.Trim();
            Document = Document.Replace(".", "").Replace("-", "");

            if(Document.Length != 11
               || Document.Equals("11111111111")
               || Document.Equals("22222222222")
               || Document.Equals("33333333333")
               || Document.Equals("44444444444")
               || Document.Equals("55555555555")
               || Document.Equals("66666666666")
               || Document.Equals("77777777777")
               || Document.Equals("88888888888")
               || Document.Equals("99999999999")
               )
                return false;

            documentTemp = Document.Substring(0, 9);

            sum = 0;
            for (int i = 0; i < 9; i++)
                sum += int.Parse(documentTemp[i].ToString()) * multiplier1[i];

            rest = sum % 11;

            if(rest < 2)
                rest = 0;
            else 
                rest = 11 - rest;

            digit = rest.ToString();
            documentTemp = documentTemp + digit;

            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(documentTemp[i].ToString()) * multiplier2[i];

            rest = sum % 11;

            if(rest < 2)
                rest = 0;
            else 
                rest = 11 - rest;

            digit = digit + rest.ToString();

            return Document.EndsWith(digit);
        }

    }
}
