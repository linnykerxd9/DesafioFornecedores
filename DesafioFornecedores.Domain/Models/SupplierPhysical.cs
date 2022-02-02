using System;
using System.Collections.Generic;
using DesafioFornecedores.Domain.Tools;

namespace DesafioFornecedores.Domain.Models
{
    public class SupplierPhysical : Supplier
    {
        public string FullName { get; private set; }
        public string Cpf { get; private set; }
        public DateTime BirthDate  { get;private  set; }

        public SupplierPhysical()
        {
        }

        public SupplierPhysical(string fantasyName, string fullName, string cpf, DateTime birthDate,
                               bool active, Email email, Address address,List<Phone> phone)
                                : base(active,address,email, phone,fantasyName)
        {
            SetFullName(fullName);
            SetCpf(cpf);
            SetBirthDate(birthDate);
        }

        public void SetFullName(string fullName){
            StringEmptyOrNull(fullName,"Full name");

            FullName = fullName;
        }
      
        public void SetCpf(string cpf){
            if(!cpf.IsCpf())
                throw new DomainExceptions("Cpf is invalid");

            Cpf = cpf;
        }
        public void SetBirthDate(DateTime date){
            if(DateTime.Now < date)
                throw new DomainExceptions("Date invalid");


            BirthDate = date;
        }


        private void StringEmptyOrNull(string text,string message){
             if(string.IsNullOrEmpty(text))
             throw new DomainExceptions($"{message} cannot be empty");
        }
    }
}