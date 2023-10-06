# AgendaAi

## Entidades

### Usu�rio
O usu�rio � a primeira entidade da aplica��o, ele � respons�vel por se cadastrar e fazer login na aplica��o. O usu�rio pode ser um cliente, prestador de servi�o ou um admnistrador.

### Profissional
O profissional � um usu�rio que pode ser contratado para realizar um servi�o. Ele pode ser um barbeiro, pintor, tatuador, etc.

### Preferencia
As preferencias s�o configura��es da aplica��o definidas pelo admnistrador. Elas podem ser usadas para definir o tempo de dura��o de um servi�o, o tempo de anteced�ncia para cancelar um servi�o, etc.

### Agendamento
O agendamento � a entidade que representa um servi�o que foi agendado por um cliente. Ele � composto por um cliente, um profissional, uma data e um servi�o.

### Horario Disponivel
O horario disponivel � a entidade que representa um horario que um profissional est� disponivel para atender. Ele � composto por um profissional e uma data.

## A fazer

- [x] Criar profissional
- [x] Criar preferencia
- [x] Criar usuario
- [x] Criar agendamento
- [x] Criar horario disponivel
- [x] Criar cliente
- [x] Relacionar profissional com agendamentos e horarios disponiveis
- [ ] Criar servi�os e relacionar com agendamentos
- [ ] Criar endere�o
- [ ] Criar interfaces