async function validar(): Promise<void> {
    const inputElement = document.getElementById('input') as HTMLTextAreaElement;
    const resultadoElement = document.getElementById('resultado') as HTMLPreElement;

    const input = inputElement.value;

    const response = await fetch('/json/validar', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ json: input })
    });

    const result = await response.json();

    if (response.ok && result.valido) {
        resultadoElement.textContent = "✅ JSON Válido\n\n" + result.jsonFormatado;
        resultadoElement.classList.remove('text-red-400');
        resultadoElement.classList.add('text-green-400');
    } else {
        resultadoElement.textContent = "❌ JSON Inválido\n\n" + result.erro;
        resultadoElement.classList.remove('text-green-400');
        resultadoElement.classList.add('text-red-400');
    }
}