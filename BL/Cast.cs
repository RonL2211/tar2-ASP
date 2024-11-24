namespace Matala1_ASP.BL
{
    public class Cast
    {
        string id;
        string name;
        string role;
        //DateOnly date;
        string date;
        string country;
        string photoUrl;
        static List<Cast> CastList = new List<Cast>();

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Role { get => role; set => role = value; }
        public string Date { get => date; set => date = value; }
        public string Country { get => country; set => country = value; }
        public string PhotoUrl { get => photoUrl; set => photoUrl = value; }

        static public bool Insert(Cast CastListToInsert)
        {
            foreach (var cast in CastList)
            {
                if (cast.Id == CastListToInsert.id)
                {
                    return false;
                }
            }
            try
            {
                CastList.Add(CastListToInsert);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        static public List<Cast> Read()
        {
            return CastList;
        }

    }
}

