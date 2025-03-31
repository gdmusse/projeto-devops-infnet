pipeline {
    agent any

    environment {
        APP_NAME    = "calculadora"
        IMAGE_NAME  = "gdmusse/${env.APP_NAME}"
        BRANCH_NAME = GIT_BRANCH.replaceFirst(/^origin\//, '')
    }

    stages {
        stage('Checkout') {
            steps {
                git 'https://github.com/gdmusse/projeto-devops-infnet.git'
            }
        }

        stage('Instalar Dependências') {
            steps {
                script {
                    bat 'dotnet restore'
                }
            }
        }

        stage('Executar Testes') {
            steps {
                script {
                    bat 'dotnet test --logger trx --results-directory TestResults'
                }
            }
            post {
                always {
                    script {
                        junit 'TestResults/*.trx'  // Gera relatório no Jenkins
                    }
                }
            }
        }

        stage('Build, testando e empacotando') {
            steps {
                script {
                    echo "Compilando, testando e empacotando a aplicação..."
                    app = docker.build("${env.IMAGE_NAME}:${env.BRANCH_NAME}-${env.BUILD_ID}", '.')
                }
            }
        }

        stage('Docker image push') {
            steps {
                script {
                    docker.withRegistry('https://registry.hub.docker.com/', 'dockerhub') {
                        app.push("${env.BUILD_ID}")
                        app.push('latest')
                    }
                }
            }
        }

        stage('Deploy') {
            steps {
                script {
                    echo "🚀 Realizando o deploy..."

                    // Para o container antigo se ele existir
                    try {
                        bat "docker rm -f ${env.APP_NAME}-${env.BRANCH_NAME} || true"
                    } catch (Exception e) {
                        echo "Nenhum container antigo rodando. Vamos seguir com o deploy novo!"
                    }

                    // Roda o novo container
                    docker.image("${env.IMAGE_NAME}:${env.BRANCH_NAME}-${env.BUILD_ID}").run("--name ${env.APP_NAME}-${env.BRANCH_NAME}")

                    echo "✅ Deploy finalizado com sucesso!"
                }
            }
        }
    }

    post {
        success {
            echo "Pipeline concluído com sucesso!"
        }
        failure {
            echo "Pipeline falhou!"
        }
    }
}
