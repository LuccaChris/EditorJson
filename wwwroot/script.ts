   async function validar() {
            const json = document.getElementById("input").value;
            const res = await fetch("/json/validar", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({ json })
            });

            const data = await res.json();
            const result = document.getElementById("resultado");

            if (data.valido) {
                result.textContent = data.jsonFormatado;
                result.style.color = "green";
            } else {
                result.textContent = "Erro: " + data.erro;
                result.style.color = "red";
            }
        }