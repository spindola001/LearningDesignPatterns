# Design Patterns

- Aqui você encontra exemplos simples das implementações dos Design Patterns descritos no site "https://refactoring.guru/pt-br/design-patterns"
- São implementações simples, pois a ideia é fixar os conceitos desses padrões na cabeça e deixar documentado, até mesmo para que outras pessoas consultem.

# Padrões criacionais

- São padrões pensados para criar objetos com mais flexibilidade e reusabilidade.

## Factory Method

- Um padrão que dispõe de uma interface para criar objetos em uma superclasse, e permite que suas subclasses digam o tipo de objeto que deve ser criado.
  - Basicamente você tem uma interface que representa o produto, ou seja uma generalização daquele objeto que será criado
  - A partir disso temos classes que representam o produto concreto - imagine o exemplo de botões sendo criados para diferentes sistemas operacionais. Botao é o produto, já BotaoWindows é o produto concretor
    - Por isso, a classe BotaoWindows (Produto concreto) irá herdar da classe Botao, que terá todos os metódos gerais que uma classe Botao tiver que ter.
  - Depois temos uma classe abstrata Creator, que tera um método FactoryMethod, e também poderá ter uma implementação padrão dele, ou outras regras de negócios ligadas a criação dos objetos.
  - Herdando da classe creator, temos as classes ConcreteCreator, que irão sobrescrever o método FactoryMethod para retornar um produto concreto
- Com esse padrão você pode extender seu código de maneira simples e sem ter que alterar nada que já esteja funcionando (Respeitando o princípio OCP - SOLID)
- Você também pode reutilizar objetos, ao invés de recriá-los sempre
