﻿using Application.CQRS.Products.Commands.Requests;
using Application.CQRS.Products.Commands.Responses;
using AutoMapper;
using Common.Exceptions;
using Common.GlobalResponses.Generics;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Products.Handlers.CommandHandlers;

public sealed class CreateProductHandler(IUnitOfWork unitOfWork,IMapper mapper,IValidator<CreateProductRequest> validator)

: IRequestHandler<CreateProductRequest, ResponseModel<CreateProductResponse>>
{
   private readonly IMapper _mapper=mapper; 

    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    //validator qosuldu
    private readonly IValidator<CreateProductRequest> _validator= validator;

    public async Task<ResponseModel<CreateProductResponse>>
    
    Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {

        Product product = new()
        {
            Name = request.Name,
        };
        //var mappedProduct = _mapper.Map<Product>(request);  

        //if (string.IsNullOrEmpty(product.Name))
        //{

        //    throw new BadRequestException("The Product Sended for add is empty.Please add the correct properties for Product and send request again");
        //    //return new ResponseModel<CreateProductResponse>
        //    //{
        //    //    Data = null,
        //    //    //error varsa null data atir cunki adam mene Product add edmek ucun request atir tutaqki frontdan ve burda bir problemi men yoluyramkiii bu obyektde isdenilen propertyni verib add edmek isdeyir yoxsa agzna geleni yazib doldurub .Onu da yoxluyram ve gorremki bu bosdusa men product add edmirem bir basa response gonderiremki bosdur
        //    //    Errors = ["The Product Sended for add is empty.Please add the correct properties for Product and send request again"]
        //    //    ,IsSuccess = false

        //    //};

        //}

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

