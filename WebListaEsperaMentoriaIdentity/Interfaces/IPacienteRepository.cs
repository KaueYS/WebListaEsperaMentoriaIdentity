﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebListaEsperaMentoriaIdentity.DTO;
using WebListaEsperaMentoriaIdentity.Models;

namespace WebListaEsperaMentoriaIdentity.Interfaces
{
    public interface IPacienteRepository
    {
        Task <List<ProfissionalModel>> BuscarProfissional();
        //Task <List<PacienteModel>> Buscar(PacienteBuscarDTQ pacienteBuscarQuery);
        Task <List<PacienteModel>> Buscar();
        Task <PacienteModel> BuscarPorId(PacienteBuscarDTQ pacienteBuscarQuery);
        //Task <List<PacienteModel>> BuscarAsync();
        //Task <List<PacienteModel>> BuscarFinalizadosAsync();
        Task <PacienteModel> EditarAsync(PacienteModel model);
        Task <PacienteModel> CriarAsync(PacienteModel model);
        Task< PacienteModel> DeletarAsync(Guid id);
    }
}
