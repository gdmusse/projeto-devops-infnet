pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                git 'https://github.com/gdmusse/projeto-devops-infnet.git'
            }
        }
        stage('Build') {
            steps {
                script {
                    sh 'dotnet build'
                }
            }
        }
        stage('Test') {
            steps {
                script {
                    sh 'dotnet test'
                }
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying application...'
            }
        }
    }
}
