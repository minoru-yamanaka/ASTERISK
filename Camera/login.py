import requests

def Logar(email, senha):
    data = { 'email': email, 'password': senha }

    try:
        resposta = requests.post('https://localhost:7148/v1/login/signin', json=data, verify=False)

        if resposta.status_code == 200:
            return resposta.json()['data']['token']
        else:
            print(f"Erro ao fazer login. Status Code: {resposta.status_code}")
            return False

    except Exception as e:
        print(f"Erro ao fazer login: {e}")
        return False
