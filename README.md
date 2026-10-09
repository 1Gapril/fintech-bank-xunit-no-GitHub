# FintechBank - Sistema Bancário com Testes em xUnit

## 👥 Participantes e Papéis no Projeto

| Desenvolvedor | Nome Completo | Foco / Responsabilidade |
| :--- | :--- | :--- |
| **Desenvolvedor 1A** | [Nome do Integrante 1] | **Dev Backend (Conta Corrente):** Criação da estrutura base e implementação das regras da classe `ContaCorrenteService.cs`. |
| **Desenvolvedor 1B** | [Nome do Integrante 2] | **Dev Backend (Empréstimos):** Implementação das regras de negócio e cálculos da classe `EmprestimoService.cs`. |
| **Desenvolvedor 2** | [Nome do Integrante 3] | **QA / Testes Unitários:** Escrita de 100% das suítes de testes parametrizados (`[Theory]` / `[InlineData]`) para ambas as classes. |
| **Desenvolvedor 3** | **Seu Nome Aqui** | **Documentação e DevOps:** Configuração do repositório remoto, gestão do `.gitignore`, Licença MIT e README. |


## 📋 Visão Geral da Aplicação
O **FintechBank** é uma aplicação demonstrativa desenvolvida em ecossistema .NET para simular operações bancárias essenciais, como controle de taxas de manutenção, validações de saques em contas correntes e análise e cálculo de parcelas de empréstimos com base no score de crédito do cliente. 

O foco principal do projeto é demonstrar a aplicação prática de **Garantia de Qualidade de Software** através de testes unitários parametrizados e robustos.

## 🛠️ Requisitos Técnicos
* **Framework:** .NET 10
* **Linguagem:** C#
* **Framework de Testes:** xUnit

## 🧠 Regras de Negócio Implementadas

### 1. ContaCorrenteService
Responsável pelas validações e taxas aplicadas às contas dos clientes:
* **CalcularTaxaManutencao:** Define a tarifa mensal do cliente com base no saldo e categoria.
  * Saldo ≥ R\$ 5.000,00 *OU* Cliente Especial = **Isento (R\$ 0,00)**.
  * Saldo entre R\$ 1.000,00 e R\$ 4.999,99 (e não especial) = **R\$ 12,50**.
  * Saldo menor que R\$ 1.000,00 (e não especial) = **R\$ 25,00**.
* **PodeRealizarSaque:** Permite o saque apenas se o valor solicitado for menor ou igual à soma do `Saldo + Limite do Cheque Especial`.

### 2. EmprestimoService
Gerencia a simulação e concessão de linhas de crédito:
* **CalcularValorParcela:** Aplica juros sobre o valor total baseado no Score de Crédito e divide pelo número de parcelas:
  * Score ≥ 700 = **5% de juros** (`valorTotal * 1.05`).
  * Score entre 500 e 699 = **12% de juros** (`valorTotal * 1.12`).
  * Score < 500 = **20% de juros** (`valorTotal * 1.20`).
* **AprovarEmprestimo:** O empréstimo só é aprovado se o valor da parcela comprometer, no máximo, **30% da renda mensal** do cliente.

---

## 🧪 Estrutura de Testes Parametrizados (`[Theory]` / `[InlineData]`)
Para garantir a cobertura eficiente de múltiplos cenários sem repetir código, utilizamos os atributos nativos do **xUnit**:
* **`[Theory]`**: Indica que o método é um teste que aceita parâmetros externos, permitindo testar múltiplos fluxos alternativos da mesma regra de negócio.
* **`[InlineData(...)]`**: Fornece os valores de entrada e o resultado esperado diretamente para a execução do teste.

Cada cenário de borda especificado nas regras de negócio (como variações de score e faixas de saldo) possui uma linha correspondente de `[InlineData]` mapeada nas suítes de teste.

---

## 🚀 Como Executar o Projeto Localmente

### 1. Clonar o Repositório
Abra o seu terminal e execute o comando:
```bash
git clone https://github.com/1Gapril/fintech-bank-xunit-no-GitHub.git
cd fintech-bank-xunit-no-GitHub
```

### 2. Compilar a Solução
Para restaurar as dependências e buildar todos os subprojetos da solução, execute:
```bash
dotnet build
```

### 3. Executar os Testes Unitários
Para validar se todas as regras de negócio estão funcionando conforme o esperado e garantir que 100% dos testes passem:
```bash
dotnet test
```
