window.addEventListener("load", function () {
    const token = "secrettoken123";

    const observer = new MutationObserver(() => {
        const authDialog = document.querySelector(".modal-ux-content");
        const input = authDialog?.querySelector('input[type="text"], input[type="password"], input');

        if (authDialog && input && !authDialog.querySelector("#show-secret-btn")) {
            const btn = document.createElement("button");
            btn.id = "show-secret-btn";
            btn.textContent = "Show secret token";
            Object.assign(btn.style, {
                marginTop: "8px",
                background: "#007bff",
                color: "white",
                border: "none",
                borderRadius: "4px",
                padding: "6px 10px",
                cursor: "pointer",
                display: "block",
            });

            const tokenText = document.createElement("div");
            tokenText.textContent = token;
            Object.assign(tokenText.style, {
                marginTop: "8px",
                fontFamily: "monospace",
                fontSize: "14px",
                background: "#f4f4f4",
                border: "1px solid #ddd",
                borderRadius: "4px",
                padding: "6px 8px",
                wordBreak: "break-all",
                display: "none",
            });

            btn.addEventListener("click", async (e) => {
                e.preventDefault();
                e.stopPropagation();

                const isHidden = tokenText.style.display === "none";
                if (isHidden) {
                    await navigator.clipboard.writeText(token);
                    tokenText.style.display = "block";
                    btn.textContent = "Hide secret token";
                } else {
                    tokenText.style.display = "none";
                    btn.textContent = "Show secret token";
                }
            });

            input.parentElement.appendChild(btn);
            input.parentElement.appendChild(tokenText);
        }
    });

    observer.observe(document.body, { childList: true, subtree: true });
});
