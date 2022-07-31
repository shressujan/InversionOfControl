namespace Api.Models
{
    public class VehicleInfo
    {
        public VehicleInfo()
        {
            
        }

        public string LisencePlateNumber { get; set; } = null!;

        public VehicleMake VehicleMake { get; set; }

        public VehicleModel VehicleModel { get; set; }

        public Color VehicleColor { get; set; }
    }

    public enum VehicleMake
    {
        HONDA,
        NISSAN,
        TOYOTA,
        ACCURA,
        LEXUS,
        AUDI,
        MITSUBISHI
    }

    public enum VehicleModel
    {
        ALTIMA,
        CIVIC,
        ACCORD,
        MURANO,
        NXT,
        CRV
    }

    public enum Color
    {
        BLACK,
        GREY,
        SILVER,
        MAROON,
        WHITE
    }
}
