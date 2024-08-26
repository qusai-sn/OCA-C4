
async function fetchCategories() {
    try {
        const response = await fetch('https://localhost:7011/api/Categories');
        const categories = await response.json();

         const dropdown = document.getElementById('categoryDropdown');
        categories.forEach(category => {
            const a = document.createElement('a');
            a.href = '#';
            a.textContent = category.categoryName;
            a.onclick = () => fetchProductsByCategory(category.categoryId);
            dropdown.appendChild(a);
        });

         const input_ddl = document.querySelectorAll('#ddl-categories');
        input_ddl.forEach(selectElement => {
            categories.forEach(category => {
                const option = document.createElement('option');
                option.value = category.categoryId;
                option.textContent = category.categoryName;
                selectElement.appendChild(option);
            });
        });

    } catch (error) {
        console.error('Error fetching categories:', error);
    }
}

async function fetchProductsByCategory(categoryId) {
    try {
        const response = await fetch(`https://localhost:7011/api/Products/category/${categoryId}`);
        const products = await response.json();
        const grid = document.getElementById('productGrid');
        grid.innerHTML = ''; 

        products.forEach(product => {
            const div = document.createElement('div');
            div.className = 'card';
            div.onclick = () => viewProductDetails(product.productId);
            div.innerHTML = `
                <img src="./images/${product.productImage}" alt="${product.productName}" style="width:300px;height:auto;">
                <div class="card__content">
                    <p class="card__title">${product.productName}</p>
                    <p class="card__description">${product.description}</p>
                </div>
            `;
            grid.appendChild(div);
        });

    } catch (error) {
        console.error('Error fetching products:', error);
    }
}

async function viewProductDetails(productId) {
try {
const response = await fetch(`https://localhost:7011/api/Products/${productId}`);
const product = await response.json();
const detailsContainer = document.getElementById('product-details-container');

detailsContainer.innerHTML = `
    <div>
        <h2>${product.productName}</h2>
        <p><strong>Description:</strong> ${product.description}</p>
        <p><strong>Price:</strong> $${product.price}</p>
        <img src="./images/${product.productImage}" alt="${product.productName}" style="width:300px;height:auto;">
        <button onClick="showUpdateForm(${product.productId}, '${product.productName}', '${product.description}', ${product.price}, ${product.categoryId})">Update Product Details</button>
        <div id="updateForm"> </div>
    </div>
`;
} catch (error) {
console.error('Error fetching product details:', error);
}
}

function showUpdateForm(productId, productName, description, price, categoryId) {
const updateForm = document.getElementById('updateForm');
updateForm.innerHTML = `
<h3>Update Product</h3>
<form id="updateProductForm" enctype="multipart/form-data">
    <label for="updateProductName">Product Name:</label>
    <input type="text" id="updateProductName" name="productName" value="${productName}" required><br>

    <label for="updateDescription">Description:</label>
    <textarea id="updateDescription" name="description" required>${description}</textarea><br>

    <label for="updatePrice">Price:</label>
    <input type="number" id="updatePrice" name="price" value="${price}" required><br>

    <label for="updateCategory">Category:</label>
    <select id="updateCategory" name="categoryId" required>
        <!-- Categories will be populated here by JavaScript -->
    </select><br>

    <label for="updateProductImage">Product Image:</label>
    <input type="file" id="updateProductImage" name="productImage"><br>

    <button type="button" onclick="UpdateProduct(${productId})">Update Product</button>
</form>
`;

// Populate categories in the update form
fetchCategoriesForUpdate(categoryId);
}

async function fetchCategoriesForUpdate(selectedCategoryId) {
try {
const response = await fetch('https://localhost:7011/api/Categories');
const categories = await response.json();

const categorySelect = document.getElementById('updateCategory');
categories.forEach(category => {
    const option = document.createElement('option');
    option.value = category.categoryId;
    option.textContent = category.categoryName;
    if (category.categoryId === selectedCategoryId) {
        option.selected = true;
    }
    categorySelect.appendChild(option);
});
} catch (error) {
console.error('Error fetching categories:', error);
}
}

async function UpdateProduct(productId) {
const formData = new FormData(document.getElementById('updateProductForm'));

try {
const response = await fetch(`https://localhost:7011/api/Products/${productId}`, {
    method: 'PUT',
    body: formData
});

if (response.ok) {
    const contentType = response.headers.get("content-type");
    let product = null;
    if (contentType && contentType.indexOf("application/json") !== -1) {
        product = await response.json(); // Parse JSON only if content is JSON
    }
    alert('Product updated successfully!');
    console.log('Product updated:', product);
    // Optionally, refresh the product details view
    viewProductDetails(productId);
} else {
    const errorMessage = await response.text();
    console.error('Failed to update product:', errorMessage);
    alert('Failed to update product: ' + errorMessage);
}
} catch (error) {
console.error('Error updating product:', error);
alert('An error occurred while updating the product.');
}
}

async function addProductFromForm() {
    const formData = new FormData(document.getElementById('productForm'));

    // Get selected categoryId from dropdown
    const categoryId = document.getElementById('ddl-categories').value;
    formData.append('categoryId', categoryId);

    try {
        const response = await fetch('https://localhost:7011/api/Products/category/' + categoryId, {
            method: 'POST',
            body: formData
        });

        if (response.ok) {
            alert('Product added successfully!');
            document.getElementById('productForm').reset();
            fetchProductsByCategory(categoryId); // Optionally, refresh the product grid
        } else {
            const errorMessage = await response.text();
            alert('Failed to add product: ' + errorMessage);
        }
    } catch (error) {
        console.error('Error adding product:', error);
        alert('An error occurred while adding the product.');
    }
}
// Fetch categories on page load
window.onload = function() {
    fetchCategories();
};
 