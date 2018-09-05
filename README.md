# Nome do projeto - Baseado no Motherload

[Jogo original](https://www.kongregate.com/games/XGenStudios/motherload)

Nosso jogo será uma versão modificada do Motherload com algumas modificações mas mantendo o espirito do jogo original.

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
| A decidir | > 6201       | Jade         |

## Minérios
A seguir, a tabela com todos os minérios que podem ser cavados.

| Minério        | Preciosidade  | Camada    | Preço     | Peso      | Pontos    |
|:--------------:|:-------------:|:---------:|:---------:|:---------:|:---------:|
| Terra          | Nenhuma       | Todas     | F$ 0      | A decidir | A decidir |
| Carvão         | Baixa         | > 50      | A decidir | A decidir | A decidir |
| Cobre          | Baixa         | > 100     | A decidir | A decidir | A decidir |
| Estanho        | Baixa         | > 300     | A decidir | A decidir | A decidir |
| Pedra          | Nenhuma       | > 500     | F$ 0      | A decidir | A decidir |
| Aluminio       | Baixa         | > 500     | A decidir | A decidir | A decidir |
| Ferro          | Média         | > 700     | A decidir | A decidir | A decidir |
| Chumbo         | Média         | > 900     | A decidir | A decidir | A decidir |
| Pirita         | Muito Baixa   | > 1200    | A decidir | A decidir | A decidir |
| Tungstenio     | Média         | > 1600    | A decidir | A decidir | A decidir |
| Prata          | Média         | > 2000    | A decidir | A decidir | A decidir |
| Ouro           | Média         | > 2400    | A decidir | A decidir | A decidir |
| Ametista       | Alta          | > 2800    | A decidir | A decidir | A decidir |
| Titânio        | Alta          | > 3200    | A decidir | A decidir | A decidir |
| Lava           | Nenhuma       | > 3200    | F$ 0      | A decidir | A decidir |
| Lapis-Lazuli   | Alta          | > 3600    | A decidir | A decidir | A decidir |
| Àgata-Azul     | Alta          | > 4000    | A decidir | A decidir | A decidir |
| Bolsão de gás  | Nenhuma       | > 4000    | F$ 0      | A decidir | A decidir |
| Rubi           | Alta          | > 4400    | A decidir | A decidir | A decidir |
| Quartzo        | Rara          | > 4800    | A decidir | A decidir | A decidir |
| Esmeralda      | Rara          | > 5200    | A decidir | A decidir | A decidir |
| Diamante       | Rara          | > 5600    | A decidir | A decidir | A decidir |
| Obsidian       | Nenhuma       | > 6000    | F$ 0      | A decidir | A decidir |
| Jade           | Rara          | > 6000    | A decidir | A decidir | A decidir |
| Uránio         | Rara          | > 6400    | A decidir | A decidir | A decidir |
| Headium        | Super rara    | Aleatório | A decidir | A decidir | A decidir |
| Ruzium         | Super rara    | Aleatório | A decidir | A decidir | A decidir |
| Brunium        | Super rara    | Aleatório | A decidir | A decidir | A decidir |

> Os minérios Headium, Ruzium e Brunium são apenas invenções baseados nos nomes dos autores.

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

| Material    | Propriedades  | Dureza     | Durabilidade |
|:-----------:|:-------------:|:----------:|:------------:|
| Headium     | Velocidade    | Super rara | 250 blocos   |
| Ruzium      | A decidir     | A decidir  | 250 blocos   |
| Brunium     | A decidir     | A decidir  | 250 blocos   |

> Broca de cobre será a broca padrão.
> Brocas super raras mineram em qualquer camada.

### Motores

A seguir, os tipos de motor que serão possiveis de comprar.

| Motor       | Cavalos       | Custo         |
|:-----------:|:-------------:|:-------------:|
| *A vapor*   | Nenhuma       | Nenhum        |
| Alcool      | A decidir     | A decidir     |
| Gasolina    | A decidir     | A decidir     |
| Eletrica    | A decidir     | A decidir     |
| Titânio     | A decidir     | A decidir     |
| Rubi        | A decidir     | A decidir     |
| Diamante    | A decidir     | A decidir     |
| Jade        | A decidir     | A decidir     |

> Motor à vapor será o motor padrão.

## Construções

Havera alguns predios no qual o jogador poderá interagir, eles serão:

- Posto de gasolina: Onde o jogador poderá reabastecer seu veiculo.
- Mercado: Onde o jogador venderá os minérios e ligas, e compará itens.
- Fornalha: Onde o jogador pode fundir minérios em ligas.

## Itens

A seguir, todos os itens usaveis pelo jogador:

- Galão de gasolina: Usado para reabastecer a gasolina do robô.
- Teleportador: Usado para se teleportar para a superficie.
- C4: Usado para explodir uma pequena area.
