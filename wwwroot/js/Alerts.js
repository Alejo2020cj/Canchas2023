
<script>
    function abrirModal() {
        Swal.fire({
            position: 'top-end',
            icon: 'success',
            title: 'Your work has been saved',
            showConfirmButton: false,
            timer: 1500

        }).then((result) => {
            if (result) {

                var frmEnviar = document.getElementById("frmEnviar");
                frmEnviar.submit();
            }

        })

    }

</script>
