# Nome do projeto - Baseado no Motherload


[Jogo original](https://www.kongregate.com/games/XGenStudios/motherload) - [Wiki](http://xgenstudios.wikia.com/wiki/Motherload)
---

Nosso jogo será uma versão modificada do Motherload mas mantendo o espirito do jogo original.

Os autores deste projeto são:
* [Vinícius Lourenço](https://github.com/H4ad)
* Ruziel Junior
* Bruno

## Conteudo
- [Camadas](#camadas)
- [Minérios](#minérios)
	- [Ligas metálicas](#ligas-metálicas)
- [Robô](#robô)
	- [Brocas](#brocas)
	- [Motores](#motores)
	- [Tanque de combustivel](#tanque-de-combustivel)
	- [Armazenamento](#armazenamento)
	- [Radiadores](#radiadores)
- [Moeda](#moeda)
- [Construções](#construções)
- [Itens](#itens)

## Camadas
Assim como no Motherload, este jogo terá suas camadas e elas ajudarão a separar e organizar os minérios.
Para este projeto, a profundidade máxima será 6666.

Haverão 8 camadas, e cada vez que você ultrapassa uma camada, a terra e as rochas irão ficar mais duras e consequentemente o jogador precisará fazer upgrades em sua broca.

| Nome      | Profundidade | Broca miníma |
|:---------:|:------------:|:------------:|
| A decidir | 0~500        | Cobre        |
| A decidir | 501~1500     | Bronze       |
| A decidir | 1501~2500    | Ferro        |
| A decidir | 2501~3500    | Tungstenio   |
| A decidir | 3501~4500    | Titânio      |
| A decidir | 4501~5500    | Rubi         |
| A decidir | 5501~6200    | Diamante     |
| A decidir | > 6200       | Jade         |

## Minérios
A seguir, a tabela com todos os minérios que podem ser cavados.

| Minério        | Preciosidade  | Camada    | Preço     | Peso      | Pontos    |
|:--------------:|:-------------:|:---------:|:---------:|:---------:|:---------:|
| Terra          | Nenhuma       | Todas     | F$ 0      | 0,1 kg    | 0         |
| Carvão         | Baixa         | > 50      | A decidir | 1,5 kg    | A decidir |
| Cobre          | Baixa         | > 100     | A decidir | 2,6 kg    | A decidir |
| Estanho        | Baixa         | > 300     | A decidir | 2,2 kg    | A decidir |
| Pedra          | Nenhuma       | > 500     | F$ 0      | 3,0 kg    | A decidir |
| Aluminio       | Baixa         | > 500     | A decidir | 2,4 kg    | A decidir |
| Ferro          | Média         | > 700     | A decidir | 2,6 kg    | A decidir |
| Chumbo         | Média         | > 900     | A decidir | 3,0 kg    | A decidir |
| Pirita         | Muito Baixa   | > 1200    | A decidir | 0,3 kg    | A decidir |
| Tungstenio     | Média         | > 1600    | A decidir | 3,2 kg    | A decidir |
| Prata          | Média         | > 2000    | A decidir | 2,2 kg    | A decidir |
| Ouro           | Média         | > 2400    | A decidir | 3,5 kg    | A decidir |
| Ametista       | Alta          | > 2800    | A decidir | 2,6 kg    | A decidir |
| Titânio        | Alta          | > 3200    | A decidir | 4,5 kg    | A decidir |
| Lava           | Nenhuma       | > 3200    | F$ 0      | 0 kg      | A decidir |
| Lapis-Lazuli   | Alta          | > 3600    | A decidir | 3,0 kg    | A decidir |
| Àgata-Azul     | Alta          | > 4000    | A decidir | 2,6 kg    | A decidir |
| Bolsão de gás  | Nenhuma       | > 4000    | F$ 0      | 0 kg      | A decidir |
| Rubi           | Alta          | > 4400    | A decidir | 4,1 kg    | A decidir |
| Quartzo        | Rara          | > 4800    | A decidir | 2,6 kg    | A decidir |
| Esmeralda      | Rara          | > 5200    | A decidir | 2,9 kg    | A decidir |
| Diamante       | Rara          | > 5600    | A decidir | 3,5 kg    | A decidir |
| Obsidiana      | Nenhuma       | > 6000    | F$ 0      | 8,0 kg    | A decidir |
| Jade           | Rara          | > 6000    | A decidir | 3,3 kg    | A decidir |
| Uránio         | Rara          | > 6400    | A decidir | 11,3 kg   | A decidir |
| Headium        | Super rara    | Aleatório | A decidir | 0,1 kg    | A decidir |
| Ruzium         | Super rara    | Aleatório | A decidir | 0,1 kg    | A decidir |
| Brunium        | Super rara    | Aleatório | A decidir | 0,1 kg    | A decidir |

> Os minérios Headium, Ruzium e Brunium são apenas invenções baseados nos nomes dos autores.

> Cada minério ocupa um métro cúbico.

> Cada métro cubico minerado, você obtem a quantidade em peso mostrado na tabela.

> Quando você minera terra, o espaço que ela ocupa é 0,05 métros cúbicos.

### Ligas metálicas
Será a possibilidade do jogador fundir dois minérios para obter uma liga.
Essas ligas serão melhores que ambos os minérios e possuirá um preço maior que a soma dos dois também.

A seguir, a tabela com todas as ligas:

| Liga metálica  | Preciosidade  | Preço         | Formula               |
|:--------------:|:-------------:|:-------------:|:---------------------:|
| Bronze         | Média         | A decidir     | x3 Cobres + x1 Estanho  |
| Aço            | Alta          | A decidir     | x1 Ferro + x1 Carvão    |

## Moeda
A moeda do jogo será o Facen (F$).

## Robô

A seguir, serão as informações relacionadas ao robo.

### Brocas
O jogador começa com a broca mais básica, a de cobre, e conforme o jogador for avançando ele poderá fazer upgrades em suas brocas.

As brocas disponíveis para a compra serão:

| Material    | Propriedades  | Perfuração | Custo      | Materiais p. criação |
|:-----------:|:-------------:|:----------:|:----------:|:--------------------:|
| *Cobre*     | Nenhuma       | 28 m/s     | Nenhum     | Nenhum               |
| Bronze      | A decidir     | 40 m/s     | A decidir  | x20 bronze           |
| Ferro       | A decidir     | 50 m/s     | A decidir  | x40 ferro            |
| Tungstenio  | A decidir     | 60 m/s     | A decidir  | x40 tungstenio       |
| Titânio     | A decidir     | 70 m/s     | A decidir  | x60 titânio          |
| Rubi        | A decidir     | 80 m/s     | A decidir  | x60 rubi             |
| Diamante    | A decidir     | 100 m/s    | A decidir  | x80 diamante         |
| Jade        | A decidir     | 120 m/s    | A decidir  | x80 Jade             |

Haverá também brocas com os minérios super raros, e cada uma terá uma propriedade diferente e uma durabilidade (coisa que as outras não terão).

A seguir, as brocas super raras:

| Material    | Propriedades  | Dureza     | Durabilidade | Perfuração |
|:-----------:|:-------------:|:----------:|:------------:|:----------:|
| Headium     | Velocidade    | Super rara | 250 blocos   | 160 m/s    |
| Ruzium      | A decidir     | A decidir  | 250 blocos   | A decidir  |
| Brunium     | A decidir     | A decidir  | 250 blocos   | A decidir  |

> Broca de cobre será a broca padrão.

> Brocas super raras mineram em qualquer camada.

### Motores

A seguir, os tipos de motor que serão possiveis de comprar.

| Motor       | Cavalos       | Custo         |
|:-----------:|:-------------:|:-------------:|
| *A vapor*   | 45            | Nenhum        |
| Alcool      | 108           | A decidir     |
| Gasolina    | 143           | A decidir     |
| Eletrica    | 234           | A decidir     |
| Titânio     | 286           | A decidir     |
| Rubi        | 338           | A decidir     |
| Diamante    | 462           | A decidir     |
| Jade        | 750           | A decidir     |

> Motor à vapor será o motor padrão.

> Cavalos calculados ao multiplicar o peso do minério mais leve em uma camada pelo espaço de armazenamento do mesmo nível.

> Cada cavalo de potência carrega 1 kg de minério.

### Tanque de combustivel

A seguir, os tipos de tanque de combustivel que o jogador pode obter para seu robô:

| Nome        | Capacidade    | Custo         |
|:-----------:|:-------------:|:-------------:|
| *A decidir* | 15 litros     | Nenhum        |
| A decidir   | 25 litros     | A decidir     |
| A decidir   | 40 litros     | A decidir     |
| A decidir   | 60 litros     | A decidir     |
| A decidir   | 80 litros     | A decidir     |
| A decidir   | 100 litros    | A decidir     |
| A decidir   | 120 litros    | A decidir     |
| A decidir   | 150 litros    | A decidir     |

### Armazenamento
A seguir, os tipos de armazenamento que o jogador pode obter para seu robô.

| Nome        | Capacidade    | Custo         |
|:-----------:|:-------------:|:-------------:|
| *Básico*    | 30 m^3        | Nenhum        |
| Pequeno     | 45 m^3        | A decidir     |
| Médio       | 65 m^3        | A decidir     |
| Grande      | 90 m^3        | A decidir     |
| Gigante     | 110 m^3       | A decidir     |
| Enorme      | 130 m^3       | A decidir     |
| Épico       | 140 m^3       | A decidir     |
| Lendário    | 150 m^3       | A decidir     |

### Radiadores
Um radiador diminui a quantidade de dano que o robô recebe ao perfurar lava, bolsão de gás, etc.

A seguir, os tipos de radiadores disponíveis para o jogador obter:

| Nome        | Efetividade   | Custo         |
|:-----------:|:-------------:|:-------------:|
| *A decidir* |  10%          | A decidir     |
| A decidir   |  25%          | A decidir     |
| A decidir   |  35%          | A decidir     |
| A decidir   |  45%          | A decidir     |
| A decidir   |  55%          | A decidir     |
| A decidir   |  70%          | A decidir     |
| A decidir   |  85%          | A decidir     |
| A decidir   |  95%          | A decidir     |

## Construções

Havera alguns predios no qual o jogador poderá interagir, eles serão:

- Posto de gasolina: Onde o jogador poderá reabastecer seu veiculo.
- Mercado: Onde o jogador venderá os minérios e ligas, e comprará itens.
- Ferreiro: Onde o jogador pode fundir minérios em ligas.
- Mecânico: Onde o jogador pode consertar o robô.

### Posto de gasolina

No posto, haverá seis opções de compra e um extra para completar o tanque.
Você poderá comprar gasolina em 5, 10, 15, 25, 50, 100 litros.

### Mercado

Todos os itens listados na tabela de minérios poderão ser vendidos e todas as categorias de robô poderam ser compradas.

### Ferreiro

Lugar onde ligas poderão ser forjadas, e quem sabe no futuro, adicionar para fazer upgrades nos equipamentos.

### Mecânico

Lugar onde o jogador poderá recuperar seu robô, restaurando em 10%, 20%, 40%, 50%, 80% e 100%.

## Itens

A seguir, todos os itens usaveis pelo jogador:

- Galão de gasolina: Usado para reabastecer a gasolina do robô.
- Teleportador: Usado para se teleportar para a superficie.
- C4: Usado para explodir uma pequena area.
- TNT - Usado para explodir uma grande area.
