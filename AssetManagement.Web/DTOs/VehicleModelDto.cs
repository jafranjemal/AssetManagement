namespace AssetManagement.Web.DTOs
{
    
        public class VehicleModelDto
        {
        public Guid Id { get; set; }
        public string ModelName { get; set; }
            public int ModelYear { get; set; }
            public Guid BrandId { get; set; } // This must match an existing VehicleBrand ID
        }
 
}
