<script>
    document.addEventListener('DOMContentLoaded', function () {
        const form = document.getElementById('createTaskForm');
    form.addEventListener('submit', function (e) {
        e.preventDefault();
    Swal.fire({
        title: 'crear tarea?',
    text: 'seguro de que deseas crear esta tarea?',
    icon: 'question',
    showCancelButton: true,
    confirmButtonText: 'Si',
    cancelButtonText: 'Cancelar'
            }).then((result) => {
                if (result.isConfirmed) {
        form.submit();
                }
            });
        });
    });
</script>