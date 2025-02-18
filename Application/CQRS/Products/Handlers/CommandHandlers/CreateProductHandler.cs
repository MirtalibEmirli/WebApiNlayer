using Application.CQRS.Products.Commands.Requests;
using Application.CQRS.Products.Commands.Responses;
using Common.Exceptions;
using Common.GlobalResponses.Generics;
using Domain.Entities;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Products.Handlers.CommandHandlers;

public sealed class CreateProductHandler(IUnitOfWork unitOfWork)
: IRequestHandler<CreateProductRequest, ResponseModel<CreateProductResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<ResponseModel<CreateProductResponse>>

    Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        Product product = new()
        {
            Name = request.Name,
        };
        if (string.IsNullOrEmpty(product.Name))
        {
            //return new ResponseModel<CreateProductResponse>
            //{
            //    Data = null,
            //    //error varsa null data atir cunki adam mene Product add edmek ucun request atir tutaqki frontdan ve burda bir problemi men yoluyramkiii bu obyektde isdenilen propertyni verib add edmek isdeyir yoxsa agzna geleni yazib doldurub .Onu da yoxluyram ve gorremki bu bosdusa men product add edmirem bir basa response gonderiremki bosdur
            //    Errors = ["The Product Sended for add is empty.Please add the correct properties for Product and send request again"]
            //    ,IsSuccess = false

            //};
            throw new BadRequestException("The Product Sended for add is empty.Please add the correct properties for Product and send request again");


        }



        await _unitOfWork.ProductRepository.AddAsync(product);
        //burda artiq geelen rquestin esas isini gorduk yeni sadece biz elave edirik ve fso

        //indi gedek cavabimizi yeni  responseModelimizi quraqki bu front bala bilsin biz ne eddik , front balaya geden cavab bizden asildir meselen sen ona gore REsponse Model yadadirsanki bu bilsinki ne is gordu , en primitiv olaraq isSuccess onun besidirki bilir fail var yoxsa yoxx gelecekde ise bu response model deyisecek yeni elave propertyler qazanacaq
        CreateProductResponse response =new () 
        {
            Id=product.Id,  
            Name = product.Name,
        };

        return new  ResponseModel<CreateProductResponse>{
            Data = response,
            IsSuccess = true,
            Errors = []
        };

    }
}

