# AgendaAi

## Entidades

### Usuário
O usuário é a primeira entidade da aplicação, ele é responsável por se cadastrar e fazer login na aplicação. O usuário pode ser um cliente, prestador de serviço ou um admnistrador.

### Profissional
O profissional é um usuário que pode ser contratado para realizar um serviço. Ele pode ser um barbeiro, pintor, tatuador, etc.

### Preferencia
As preferencias são configurações da aplicação definidas pelo admnistrador. Elas podem ser usadas para definir o tempo de duração de um serviço, o tempo de antecedência para cancelar um serviço, etc.

### Agendamento
O agendamento é a entidade que representa um serviço que foi agendado por um cliente. Ele é composto por um cliente, um profissional, uma data e um serviço.

### Horario Disponivel
O horario disponivel é a entidade que representa um horario que um profissional está disponivel para atender. Ele é composto por um profissional e uma data.

## A fazer

- [x] Criar profissional
- [x] Criar preferencia
- [x] Criar usuario
- [x] Criar agendamento
- [x] Criar horario disponivel
- [x] Criar cliente
- [x] Relacionar profissional com agendamentos e horarios disponiveis
- [ ] Criar serviços e relacionar com agendamentos
- [ ] Criar endereço
- [ ] Criar interfaces