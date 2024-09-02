using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace task_2.DTO;

public class DTOs
{

}

public partial class CategoryDTO
{

    public string CategoryName { get; set; } = null!;



}
public class AddToCartDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public int userId { get; set; }

}


public partial class ProductDTO
{

    public string ProductName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal? Price { get; set; }


    public string? ProductImage { get; set; }

}

public partial class ProductDTO2
{

    public string ProductName { get; set; } = null!;

    public string Description { get; set; }

    public decimal Price { get; set; }


    public IFormFile ProductImage { get; set; }

}
public partial class UserDTO
{

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

}
public class usersDTOs
{



    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; } = null!;

    public string username { get; set; } = null!;


}


public class Login_DTOs
{



    public string Password { get; set; } = null!;

    public string username { get; set; } = null!;


}
public class HashingClass
{
    public static void CreatePassword(string password, out byte[] PasswordHash, out byte[] PasswordSalt)
    {

        using (var l = new System.Security.Cryptography.HMACSHA512())
        {
            PasswordSalt = l.Key;
            PasswordHash = l.ComputeHash(Encoding.UTF8.GetBytes(password));
        }


    }
    public static bool VerifyPassword(string password, byte[] passwordHashed, byte[] PasswordSalt)
    {
         byte[] PasswordHash;


        using (var l = new System.Security.Cryptography.HMACSHA512(PasswordSalt))
        {
             PasswordHash = l.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        
        return passwordHashed.SequenceEqual(PasswordHash);
        

        
     }
}

