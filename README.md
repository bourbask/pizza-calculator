# pizza-calculator

Simple example of hexagonal architecture.

The purpose is to calculate the number of required pizzas for feeding a given number of persons.

We consider that:

- Everybody eats the same type of pizza and
- A pizza is composed of 6 slices

The input parameters are:

- The number of persons to feed
- The type of pizza

The domain within the hexagon calculates the number of required pizzas using the given input parameters. The hexagon uses a repository containing the average number of slices required for feeding one person depending of the type of pizza.

The project objects are:

- [PizzaCalculator](src/PizzaCalculator.cs): the domain/the hexagon
- [IPizzaCalculator](src/IPizzaCalculator.cs): primary port defining the interface of the hexagon.
- [IPizzaRepository](src/IPizzaRepository.cs): secondary port defining the external objects called by the hexagon.
- [ConsoleAdapter](src/ConsoleAdapter.cs): primary adapter reading the input parameters and calling the hexagon.
- [RepositoryAdapter](src/RepositoryAdapter.cs): secondary adapter satisfying IPizzaRepository. This adapter is called by the hexagon.

## fork purpose

I am doing some evolutions on this simple and concrete example, to put in practice the theory of this architecture.

## developed context

In the purpose of these evolutions I've developed the context of the project :

We are developing a software for the company Pizza Party which have several branches all around the world.
The concept of this pizzeria is : bigger your party is, bigger the reduction will be (like every pizzeria I guess, but don't mind)

The customer give the number of participants and the type of pizza. (evil is the plurality, so only one type allowed)

The algorithm will calculate the number of slices required for each fellow partier, depending of the type of pizza.
This will give a total number of pizzas.

The group price and number of pizza slices depend on the branch's strategy and capacity. For this reason, this information does not come from an external source. (Primary interfaces)

The average number of slices and the unit price for each type of pizza were calculated by the company's head office and made available via an API. (Secondary interfaces)

## credits

- Author of the fork : [bourbask](https://github.com/bourbask)
- Original GitHub Repository : [pizza-calculator](https://github.com/msoft/pizza-calculator)
- The article referencing the GitHub repository : [L'architecture hexagonale en 5 min](https://cdiese.fr/larchitecture-hexagonale-en-5-min/) by [Mathias Montantin](https://cdiese.fr/author/mitchoum/)
