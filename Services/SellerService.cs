﻿using SalesWebMvc.Data;
using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        //Entra a lógica de Negócio
        public List<Seller> FindAll()
        {
            return _context.Sellers.ToList();
        }

        public void Insert(Seller obj)
        {
            //obj.Department=_context.Department.First();
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Sellers.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Sellers.Find(id);
            _context.Sellers.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {

            if (!_context.Sellers.Any(x => x.Id == obj.Id))
            {

                throw new NotFoundException("Não Achei o Dado");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();

            }
            catch (DbConcurrencyException e) {
                throw new DbConcurrencyException(e.Message);
            }
           
        }

    }
}