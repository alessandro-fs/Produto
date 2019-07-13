CURSO GIT E GITHUB – SHIFT FIAP 15/09/2018 

 

MÓDULO 2 - INSTALAÇÃO E CONFIGURAÇÃO 

INSTALAR 

CRIAR PASTA 

CRIAR REPOSITÓRIO 

git init

CRIAR QUEM SOMOS 

git config –global USER.NAME “NOME MAQUINA” 

git config –global USERNAME.EMAIL “E-MAIL” 

LS –HELP (AJUDA DE TODOS COMANDOS) 

PWD - saber onde está 

CD .. (VOLTAR PASTA) 

CD [NOME PASTA] (ENTRAR PASTA) 

MKDIR (CRIAR PASTA) 

ls (LISTA  CONTEÚDO) 

ls -l (LISTA TUDO EM FORMATO LISTA) 

ls -l -a(LISTA TUDO, COMO LISTAS INCLUSIVE OCULTOS) 

clear (LIMPA TELA) git 

touch Arquivo.txt 

git status (EXIBE ARQUIVOS, COMMITS, NÃO VERSIONADOS) 

VERSIONAR ARQUIVO 

git add <TAB>(AUTO COMPLETA) 

git add CLS <PASTA>

git add . (ADICIONA TODOS) 

git add * (TUDO A MENOS QUE EU ESPECIFIQUE) 

git add *.JPG 

git commit –m “FIRST COMMIT” (VERSIONA E ADICIONA MENSAGEM) 

git log (QUEM FEZ, QUANDO FEZ, O QUE FEZ) 

git diff <nome do arquivo> meld/visual studio para visualizar graficamente

git log --reverse (Mostra de traz para frente)

git log --summary (mostra mais informações)

git log --oneline (mostra informações de forma mais resumida)

git checkout <identificador> (navegar entre as versões)

git revert HEAD~1 (voltar para uma versão da linha do tempo anterior)

git reset --hard HEAD~0 (digitar <vim> para abrir conflito)

git reset HEAD <arquivo> (remove o arquivo que eu não queira da staging area)

git checkout <commit> <arquivo> (hash e nome do arquivo)

git clean -f (excluir arquivo)

git clean -fd (excluir arquivo e pasta)

git reset --soft HEAD~<número>

git reflog (onde matém tudo que já existiu no git)

git stash (armazena na stagging area, habilita trabalhar com o arquivo anterior as alteraçãoes para continuar depois)

git stash apply (pega as modificações da stagging area e traz para a versão atual)

LINHA DO TEMPO (BRANCHE) CHAMADA HEAD -> MASTER
BRANCHE - Nome técnico para linha do tempo
GIT RESET VOLTA E MATÉM 
GIT RESET HARD VOLTA E APAGA
GIT RESET SOFT VOLTA MAS MANTÉM DADOS (APAGA COMMITS)

=====================================================================
BRANCHES E TAGS
=====================================================================
git branch<DEV>
git branch -d<DEV> (apaga a branch)
git checkout -b<DEV> (atalho, cria branch e já vai para ela)
git cherry-pick<identificador> (mescla apenas um commit na branch atual)

touch .gitignore (cria arquivo para colocar todos arquivos que não quero versionar)
	./teste/
	.config
	*.exe
	thumbs.db
	teste.txt
	gerador de gitignore.io
	
git merge <DEV>
exemplo de resolução de problemas
===============================================
<<<<<<< HEAD
ultima linha
=======
﻿teste
nova informação adicionada para teste comando git blame

=====
alteração para teste de conflitos
testes

sdfsdfsdaf
sdf
sdaf
sdf
sdaf
sdfsd
]sdfsdfd
>>>>>>> DEV
===============================================
REPOSITÓRIO REMOTO

formas de configurar servidor remoto
SLIDE 97

git pull <remote-name> <branch-name> traz do servidor remoto
git push origin master envia para o servidor remoto
git push <remote-name> <branch-name>
git fetch <remote-name> (faz download de todas branches)
git push https://github.com/alessandro-fs/Produto DEV

