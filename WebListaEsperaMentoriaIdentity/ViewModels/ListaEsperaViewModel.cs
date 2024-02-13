﻿using System;
using System.Collections.Generic;
using WebListaEsperaMentoriaIdentity.DTO;
using WebListaEsperaMentoriaIdentity.Models;

namespace WebListaEsperaMentoriaIdentity.ViewModels
{
    public class ListaEsperaViewModel : PacienteDadosBasicosViewModel
    {
        public ProfissionalModel? Profissional {  get; set; }
        public Guid? ProfissionalId { get; set; }
        public List<ListaEsperaPacienteViewModel>? Pacientes { get; set; }
        
        public Guid PacienteId { get; set; }
        public List<ProfissionalPacienteListaEsperaDTO>? ProfissionaisPacienteListaEspera { get; set; }

       


        public static implicit operator PacienteModel(ListaEsperaViewModel paciente)
        {
            return new PacienteModel
            {
                Id = paciente.Id,
                Nome = paciente.Nome,
                Email = paciente.Email,
                Telefone = paciente.Telefone,
                DataCadastro = paciente.DataCadastro,
                Observacao = paciente.Observacao,
                ProfissionalId = paciente.ProfissionalId,
                Profissional = paciente.Profissional,
                Status = paciente.Status
                
            };
        }

        public static implicit operator ListaEsperaViewModel(PacienteModel paciente)
        {
            return new ListaEsperaViewModel
            {
                Id = paciente.Id,
                Nome = paciente.Nome,
                Email = paciente.Email,
                Telefone = paciente.Telefone,
                DataCadastro = paciente.DataCadastro,
                Observacao = paciente.Observacao,
                ProfissionalId = paciente.ProfissionalId,
                Profissional= paciente.Profissional,
                Status = paciente.Status,
                
            };
        }

        public List<ListaEsperaPacienteViewModel> ConverterPaciente(List<PacienteModel> pacientes)
        {
            List<ListaEsperaPacienteViewModel> pacientesViewModel = new List<ListaEsperaPacienteViewModel>();

            foreach (var paciente in pacientes)
            {
                string telefoneFormatado = string.Empty;
                if (long.TryParse(paciente.Telefone, out long telefone))
                {
                    telefoneFormatado = telefone.ToString("(00) 00000-0000");
                }
                else
                {
                    telefoneFormatado = paciente.Telefone;
                }

                pacientesViewModel.Add(new ListaEsperaPacienteViewModel
                {
                    Id = paciente.Id,
                    Nome = paciente.Nome,
                    Email = paciente.Email,
                    Telefone = paciente.Telefone,
                    TelefoneFormatado = telefoneFormatado,
                    DataCadastro = paciente.DataCadastro,
                    Observacao = paciente.Observacao,
                    Profissional = paciente.Profissional,
                    Status = paciente.Status,
                });

            }
            return pacientesViewModel;


            //return new List<ListaEsperaPacienteViewModel>
            //{
            //    Id = paciente.Id,
            //    Nome = paciente.Nome,
            //    Email = paciente.Email,
            //    Telefone = paciente.Telefone,
            //    DataCadastro = paciente.DataCadastro,
            //    Observacao = paciente.Observacao,
            //    Profissional = paciente.Profissional,
            //    Status = paciente.Status,

            //};
        }

    }
}

