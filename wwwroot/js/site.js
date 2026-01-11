// Site-wide JavaScript

// Form validation enhancement
document.addEventListener('DOMContentLoaded', function() {
    // Auto-calculate total amount for order form
    const ticketSelect = document.getElementById('TicketId');
    const quantityInput = document.getElementById('Quantity');
    const totalAmountDisplay = document.getElementById('TotalAmountDisplay');

    if (ticketSelect && quantityInput) {
        function calculateTotal() {
            const selectedOption = ticketSelect.options[ticketSelect.selectedIndex];
            if (selectedOption && quantityInput.value) {
                const price = parseFloat(selectedOption.getAttribute('data-price')) || 0;
                const quantity = parseInt(quantityInput.value) || 0;
                const total = price * quantity;
                
                if (totalAmountDisplay) {
                    totalAmountDisplay.textContent = total.toFixed(2) + ' ₺';
                }
            }
        }

        ticketSelect.addEventListener('change', calculateTotal);
        quantityInput.addEventListener('input', calculateTotal);
    }

    // Image preview for file uploads
    const imageInput = document.getElementById('ImageFile');
    const imagePreview = document.getElementById('ImagePreview');
    
    if (imageInput && imagePreview) {
        imageInput.addEventListener('change', function(e) {
            const file = e.target.files[0];
            if (file) {
                const reader = new FileReader();
                reader.onload = function(e) {
                    imagePreview.src = e.target.result;
                    imagePreview.style.display = 'block';
                };
                reader.readAsDataURL(file);
            }
        });
    }
});

