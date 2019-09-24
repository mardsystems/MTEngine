# MTEngine

MTEngine � o acr�nimo de Message Transformation Engine, ou Motor de Transforma��o de Mensagens.

# Rotas

Existem duas rotas:

- https://localhost:44397/transformacoes
- https://localhost:44397/regras

A primeira rota serve para transformar mensagens e a segunda para gerenciar o cadastro de regras de transforma��o de mensagens.

# Banco de dados

O banco de dados ser� iniciado por padr�o com as regras j� conhecidas dos estados do Rio, Minas e Acre.

# Exemplo de transforma��o de mensagem do estado do Rio de janeiro

POST https://localhost:44397/transformacoes
Content-Type: application/xml
Regra: Rio

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

ou seja, � necess�rio criar um cabe�alho chamado "regra" contendo o nome da regra de transforma��o relativa a integra��o atual e tamb�m especificar o content-type de acordo com o tipo de media informado.

Para ver uma lista completa de todas as regras cadastradas consulte:
GET	 https://localhost:44397/regras

# Cadastro de uma nova regra:

POST https://localhost:44397/regras
Content-Type: application/json

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

O tipo de formato suportado � o Xml = 1 e o JSON = 2.

# Observa��o

Todo o sistema foi feito em 1 dia apenas.