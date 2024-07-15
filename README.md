# Projeto Console LanHouse

## Visão Geral

O projeto de console LanHouse simula o funcionamento de uma locadora de computadores, onde é possível alugar, liberar e verificar o status dos PCs disponíveis na lan house.

## Funcionalidades Implementadas

1. **Classe Desktop:**

   - Representa cada computador na lan house.
   - Atributos: número do desktop e estado de ocupação.
   - Métodos: alugar e liberar.

2. **Classe LanHouse:**

   - Gerencia a coleção de PCs (instâncias da classe Desktop).
   - Métodos: adicionar PCs, alugar, liberar e exibir status.

3. **Menu Principal (FrontendService):**
   - Interface de usuário por console.
   - Opções: alugar PC, liberar PC, verificar status dos PCs e sair do programa.
   - Implementação de validação de entrada para garantir escolhas válidas.

## Próximos Passos

1. **Implementação Adicional:**

   - Adicionar funcionalidade de verificação detalhada do status dos PCs.
   - Melhorar a interface de usuário para facilitar a navegação.

2. **Melhorias Planejadas:**
   - Implementar persistência de dados para manter informações dos PCs.
   - Adicionar suporte a múltiplos usuários com login e logout.
   - Integrar recursos de relatório e estatísticas de uso dos PCs.

## Conclusão

O projeto atual proporciona uma experiência básica de gerenciamento de PCs em uma lan house, com funcionalidades principais de aluguel, liberação e verificação de status. Futuros desenvolvimentos visam expandir a aplicação com mais recursos e melhorias na usabilidade.
