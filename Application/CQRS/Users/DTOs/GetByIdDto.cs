namespace Application.CQRS.Users.DTOs;

public class GetByIdDto
{

    //cqrs pattern haqqinda oxu arasdir https://www.gencayyildiz.com/blog/cqrs-pattern-nedir-mediatr-kutuphanesi-ile-nasil-uygulanir/   
    public int Id { get; set; }

    public string Name { get; set; }

    public string SurName { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }
}
