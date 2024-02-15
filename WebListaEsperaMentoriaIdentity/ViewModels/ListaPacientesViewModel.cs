using System;
using System.Collections.Generic;
using System.ComponentModel;
using WebListaEsperaMentoriaIdentity.DTO;
using WebListaEsperaMentoriaIdentity.Enums;
using WebListaEsperaMentoriaIdentity.Models;

namespace WebListaEsperaMentoriaIdentity.ViewModels
{
    public class ListaPacientesViewModel
    {
        //=============BASE=================================================================================
        public Guid Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Telefone { get; set; } = string.Empty;
        public string TelefoneFormatado { get; set; } = string.Empty;
        
        [DisplayName("Data do cadastro")]
        public DateTime DataCadastro { get; set; }

        public string? Observacao { get; set; }

        public StatusEnum Status { get; set; }


        //== VIEW MODEL PARA PARTIAL DIA DISPONIVEL===========================================================
        
        [DisplayName("Data disponivel")]
        public DateTime DataAgendamento { get; set; } = DateTime.Now.Date.ToLocalTime();


        //== BUSCAR PROFISSIONAIS ============================================================================

        public ProfissionalModel? Profissional {  get; set; }
        public Guid? ProfissionalId { get; set; }


        //== VIEW MODEL CONVERTE PARA TELEFONE COM MASCARA
        public List<ListaPacientesViewModel>? Pacientes { get; set; }
        
        

        //== VIEWMODEL IMPLEMENTAR A PARTIAL CREATE =========================================================
        public List<ProfissionalPacienteListaEsperaDTO>? ProfissionaisPacienteListaEspera { get; set; }



        //== VIEWMODEL PARA SELECIONAR PACIENTES POR MEDICO =================================================
        public List<PacienteModel>? ListaPacientesCadaProfissional { get; set; }
        public PacienteModel? Paciente { get; set; }



        

        public static implicit operator PacienteModel(ListaPacientesViewModel paciente)
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

        public static implicit operator ListaPacientesViewModel(PacienteModel paciente)
        {
            return new ListaPacientesViewModel
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

        public List<ListaPacientesViewModel> ConverterPaciente(List<PacienteModel> pacientes)
        {
            List<ListaPacientesViewModel> pacientesViewModel = new List<ListaPacientesViewModel>();

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

                pacientesViewModel.Add(new ListaPacientesViewModel
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
        }
    }
}

