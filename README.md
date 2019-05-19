# TechTaskWG

O __TechTaskWG__ é um sistema teste que possui uma arquitetura cliente/servidor com Windows Forms e Windows Service utilizando .Net Framework 4.0 e MySQL. TechTaskWG tem como objetivo permitir o cadastro de produtos e componentes onde um produto pode possuir vários componentes e um componente pode estar presente em vários produtos. 

A aplicação servidora, desenvolvida com Windows Service, disponibiliza serviços para criar, ler, editar e excluir produtos e componentes. Estes serviços são consumidos pela aplicação cliente, que foi desenvolvida com Windows Forms.

Foi implementado, ainda, um Setup Project para permitir a instalação do Windows Service por meio de um instalador. Ao concluir a instalação, o serviço referente ao Windows Service implementado será iniciado automaticamente.

Foram utilizadas para o desenvolvimento do projeto as seguintes ferramentas:

- [MySQL Workbench 8.0](https://dev.mysql.com/downloads/workbench/) – Gerenciador de banco de dados MySQL
- [USBWebserver v8.6](https://www.usbwebserver.net/webserver/) – Servidor web USB
- [Visual Studio 2017 Community](https://visualstudio.microsoft.com/pt-br/downloads/) – IDE de desenvolvimento

A configuração e a string de conexão com o banco de dados utilizadas neste teste encontram-se em App.config na camada DAL.
