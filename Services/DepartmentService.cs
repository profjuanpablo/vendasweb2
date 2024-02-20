﻿using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Linq;
namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvcContext _context;

        public DepartmentService(SalesWebMvcContext context) { 
            _context = context;
        }
        public async Task<List<Department>> FindAllAsync()
        {
            //necesário importar o Entityframeworkcore
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }





    }
}
