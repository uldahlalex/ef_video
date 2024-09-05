using DataAccess.Models;

namespace Api;

public class DoctorDto
{
    public string Name { get; set; }
    
    public DoctorDto(Doctor doctor)
    {
        Name = doctor.Name;

    }

    
    
}