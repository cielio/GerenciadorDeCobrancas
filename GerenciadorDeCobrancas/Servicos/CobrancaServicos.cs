using GerenciadorDeCobrancas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GerenciadorDeCobrancas.Servicos
{
    class CobrancaServicos
    {
        private readonly CobrancaContext _context;

        public CobrancaServicos(CobrancaContext context)
        {
            _context = context;
        }

        public List<Cobranca> FindAll()
        {
            return _context.Cobrancas.Include(cobranca => cobranca.Contas).ToList();  
        }

        public List<Cobranca> FindAllByDate()
        {
            return _context.Cobrancas.Include(cobranca => cobranca.Contas)
                .Where(cobranca => cobranca.Data.Month == DateTime.Today.Month).ToList();
        }
            
        public Cobranca FindById(int id)
        {
            return _context.Cobrancas.Include(cobranca => cobranca.Contas).FirstOrDefault(cobranca => cobranca.Id == id);
        }


        public void Insert(Cobranca cobranca)
        {
            //Cor Verde escuro #FF2A7A04
            //Cor Vermelho escuro #FF991305
            if (cobranca.StatusCobranca == StatusCobranca.Pago)
            {
                cobranca.Cor = "#FF2A7A04";
            }
            else
            {
                cobranca.Cor = "#FF991305";
            }

            _context.Add(cobranca);
            _context.SaveChanges();
        }


        public void Remove(int id)
        {
            var cobranca = _context.Cobrancas.Find(id);
            _context.Cobrancas.Remove(cobranca);
            _context.SaveChanges();
        }

        public void Update(Cobranca cobranca)
        {
            if (!_context.Cobrancas.Any(x => x.Id == cobranca.Id))
            {
                throw new NotFoundException("Id not found");
            }

            try
            {
                _context.Update(cobranca);
                _context.SaveChanges();

            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }
    }
}
