# BibliotecaSistem
Projeto para a conclusão do curso tecnico em Ti cujo objetivo e estabelecer uma aplicação para a biblioteca da escola.

------------------------------------------------------------------------------------------------------------------------------------------------------------------------
BlibliotecaCLI MySQL:
CREATE TABLE Livros (
    Id  INT NOT NULL AUTO_INCREMENT primary KEY,
    Titulo LONGTEXT NOT NULL,
    Autor LONGTEXT NOT NULL,
    Disponivel TINYINT(1) NOT NULL
);
CREATE TABLE Usuarios (
    Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Nome LONGTEXT NOT NULL,
    Email LONGTEXT NOT NULL,
    Senha VARCHAR(255) NOT NULL
);
CREATE TABLE Emprestimos (
    Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    DataEmprestimo DATETIME NOT NULL,
    DataDevolucao DATETIME NULL,
    UsuarioId INT NOT NULL,
    LivroId INT NOT NULL,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id),
    FOREIGN KEY (LivroId) REFERENCES Livros(Id)
);