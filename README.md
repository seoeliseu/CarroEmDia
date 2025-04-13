# Solution Structure - CarroEmDia

📦 CarroEmDia  
📁 ├── CarroEmDia.Api  
📁 ├── CarroEmDia.Application  
📁 ├── CarroEmDia.Contracts  
📁 ├── CarroEmDia.Domain  
📁 ├── CarroEmDia.Infrastructure  
📁 └── CarroEmDia.Startup  


## 🧱 DDD Layer Descriptions

### 📁 CarroEmDia.Api
Responsável por expor a aplicação para o mundo externo.  
Contém os endpoints HTTP (Minimal APIs), middlewares, autenticação/autorização, filtros, e configuração da aplicação web.

> **Regra**: Deve depender apenas de `Startup`, `Application` e `Contracts`.

---

### 📁 CarroEmDia.Application
Contém os casos de uso da aplicação (Application Services), que orquestram as ações entre as entidades do domínio e os serviços de infraestrutura.  

> **Responsabilidade**: Aplicar as regras de negócio de forma procedural (sem lógica de domínio rica).

> **Regra**: Depende de `Domain` e `Contracts`.

---

### 📁 CarroEmDia.Contracts
Define os contratos (DTOs, Interfaces de Serviços, Requests, Responses, etc) usados entre as camadas.  
Essa camada promove o **acoplamento fraco** entre as outras partes da aplicação.

> **Regra**: Não depende de nenhuma outra camada. Pode ser compartilhada com clientes externos.

---

### 📁 CarroEmDia.Domain
O coração da aplicação. Contém as **Entidades**, **Value Objects**, **Aggregates**, **Enums**, **Interfaces de Repositórios**, e **Regras de Negócio**.

> **Regra**: Não deve depender de nenhuma outra camada.

---

### 📁 CarroEmDia.Infrastructure
Responsável pela persistência de dados, integração com serviços externos, envio de e-mails, log, etc.  
Implementa as interfaces definidas na camada `Domain` ou `Contracts`.

> **Regra**: Pode depender de `Domain`, `Contracts`, e bibliotecas externas.

---

### 📁 CarroEmDia.Startup
Responsável pela composição de dependências, configurações de serviços, middlewares e inicialização da aplicação.  
Centraliza as responsabilidades de bootstrap da aplicação.

> **Regra**: Deve depender de todas as outras camadas, mas nenhuma delas deve depender de `Startup`.

---

Se quiser, posso gerar um diagrama visual dessa estrutura também. Deseja isso?

### Exemplo migration command
```Add-Migration InitialCreate -Project CarroEmDia.Infrastructure -StartupProject CarroEmDia.Api -OutputDir Data/Migrations