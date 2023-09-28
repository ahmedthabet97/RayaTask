using Microsoft.AspNetCore.Identity;

namespace Domain;

public class RayaUser: IdentityUser
{
   public bool isAgree { get; set; }    
}