namespace ObligatoriskOpgave_1_2
{
    public class NewBook
    {
        public int id { get; set; }
        public string? title { get; set; }
        public int price { get; set; }

        //Via denne bliver de 3 properties til strings.
        public override string ToString()
        {
            return $"Id: {id}, " +
                   $"Title: {title}, " +
                   $"Price: {price}";
        }

        public void ValidateTitle()
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException("The title cannot be null");
            }

            if (title.Length < 3)
            {
                throw new ArgumentException("The title must contain at least 3 characters");
            }
        }


        public void ValidatePrice()
        {
            if (price <= 0 || price >= 1200)
            {
                throw new ArgumentException("The price must be above 0 and under 1200");
            }
        }

        //Via validate metoderne, kan en exception blive smidt på skærmen, når en fejl sker.
        //Exceptionsne kan nu blive udskrivet som tekst vha. ToString metoden.
        public void Validate()
        {
            ValidateTitle();
            ValidatePrice();
        }
    }
}