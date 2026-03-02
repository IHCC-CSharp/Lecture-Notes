<script>
  import { getApiBooks } from '$lib/api/sdk.gen';

  let books = $state([]);

  $effect(() => {
    getApiBooks().then(({ data }) => books = data ?? []);
  });
</script>

<main>
  <h1>Library Book Loans</h1>

  <table border="1">
    <thead>
      <tr>
        <th>ID</th>
        <th>Title</th>
        <th>Due Date</th>
        <th>Status</th>
      </tr>
    </thead>
    <tbody>
      {#each books as book}
        <tr>
          <td>{book.id}</td>
          <td>{book.title}</td>
          <td>{new Date(book.dueDate).toLocaleDateString()}</td>
          <td>{book.returnedDate ? 'Returned' : 'Checked Out'}</td>
        </tr>
      {/each}
    </tbody>
  </table>
</main>