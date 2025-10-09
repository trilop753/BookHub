window.addEventListener("load", function () {
    const token = 'secrettoken123';

    const observer = new MutationObserver(() => {
        const authDialog = document.querySelector('.modal-ux-content');
        const input = authDialog?.querySelector('input[type="text"], input[type="password"], input');

        if (authDialog && input && !authDialog.querySelector('#show-secret-btn')) {
            const btn = document.createElement('button');
            btn.id = 'show-secret-btn';
            btn.textContent = 'Show secret token';
            btn.style.marginTop = '8px';
            btn.style.background = '#007bff';
            btn.style.color = 'white';
            btn.style.border = 'none';
            btn.style.borderRadius = '4px';
            btn.style.padding = '6px 10px';
            btn.style.cursor = 'pointer';
            btn.style.display = 'block';

            btn.onclick = async () => {
                await navigator.clipboard.writeText(token);

                const tokenText = document.createElement('div');
                tokenText.textContent = token;
                tokenText.style.marginTop = '8px';
                tokenText.style.fontFamily = 'monospace';
                tokenText.style.fontSize = '14px';
                tokenText.style.background = '#f4f4f4';
                tokenText.style.border = '1px solid #ddd';
                tokenText.style.borderRadius = '4px';
                tokenText.style.padding = '6px 8px';
                tokenText.style.wordBreak = 'break-all';

                btn.replaceWith(tokenText);
            };

            input.parentElement.appendChild(btn);
        }
    });

    observer.observe(document.body, { childList: true, subtree: true });
});
