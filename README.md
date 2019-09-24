# MTEngine

MTEngine é o acrônimo de Message Transformation Engine, ou Motor de Transformação de Mensagens.

# Rotas

Existem duas rotas:

- https://localhost:44397/transformacoes
- https://localhost:44397/regras

A primeira rota serve para transformar mensagens e a segunda para gerenciar o cadastro de regras de transformação de mensagens.

# Banco de dados

O banco de dados será iniciado por padrão com as regras já conhecidas dos estados do Rio, Minas e Acre.

# Exemplo de transformação de mensagem do estado do Rio de janeiro

```
POST https://localhost:44397/transformacoes
Content-Type: application/xml
Regra: Rio
```

```xml
<corpo>
    <cidade>
        <nome>Rio de Janeiro</nome>
        <populacao>10345678</populacao>
        <bairros>
            <bairro>
                <nome>Tijuca</nome>
                <regiao>Zona Norte</regiao>
                <populacao>135678</populacao>
            </bairro>
            <bairro>
                <nome>Botafogo</nome>
                <regiao>Zona Sul</regiao>
                <populacao>105711</populacao>
            </bairro>
        </bairros>
    </cidade>
</corpo>
```

ou seja, é necessário criar um cabeçalho chamado "regra" contendo o nome da regra de transformação relativa a integração atual e também especificar o content-type de acordo com o tipo de media informado.

Para ver uma lista completa de todas as regras cadastradas consulte:
GET	 https://localhost:44397/regras

# Cadastro de uma nova regra:

```
POST https://localhost:44397/regras
Content-Type: application/json
```

```json
{
    "nome": "Rio",
    "pathDeCidades": "/corpo/cidade",
    "pathDoNomeDaCidade": "nome",
    "pathDoNumeroDeHabitantesDaCidade": "populacao",
    "pathDeBairros": "bairros/bairro",
    "pathDoNomeDoBairro": "nome",
    "pathDoNumeroDeHabitantesDoBairro": "populacao",
    "tipoDeFormato": 1
}
```

O tipo de formato suportado é o Xml = 1 e o JSON = 2.

# Observação

Todo o sistema foi feito em 1 dia apenas.
