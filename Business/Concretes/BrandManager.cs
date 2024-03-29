﻿using Business.Abstract;
using Business.Dtos.Request;
using Business.Dtos.Responses;
using DataAccess.Abstract;
using Entities.Concretes;

namespace Business.Concretes;

public class BrandManager : IBrandService
{
    private readonly IBrandDal _brandDal;

    public BrandManager(IBrandDal brandDal)
    {
        _brandDal = brandDal;
    }

    public CreatedBrandResponse Add(CreateBrandRequest createBrandRequest)
    {
        //mapping --> AutoMapper yapacak.
        Brand brand = new Brand();
        brand.Name = createBrandRequest.Name;
        brand.CreatedDate=DateTime.Now;

        _brandDal.Add(brand);

        CreatedBrandResponse createdBrandResponse = new CreatedBrandResponse();
        createdBrandResponse.Name = brand.Name;
        createdBrandResponse.Id = 4;
        createdBrandResponse.CreatedDate=brand.CreatedDate;

        return createdBrandResponse;


    }

    public List<GetAllBrandResponse> GetAll()
    {
        List<Brand> brands= _brandDal.GetAll();
        List<GetAllBrandResponse> getAllBrandResponses=new List<GetAllBrandResponse>();

        foreach(var brand in brands)
        {
            GetAllBrandResponse getAllBrandResponse=new GetAllBrandResponse();
            getAllBrandResponse.Name = brand.Name;
            getAllBrandResponse.Id=brand.Id;
            getAllBrandResponse.CreatedDate = brand.CreatedDate;

            getAllBrandResponses.Add(getAllBrandResponse);
        }
        return getAllBrandResponses;
    }
}
