SELECT pr.Nome, count(pa.Id) FROM PROFISSIONAL as pr

Left join PACIENTE as pa on pr.Id = pa.ProfissionalId

Group by pr.Nome




