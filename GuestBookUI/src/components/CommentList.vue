<template>
  <div>
    <q-table
      :rows="comments"
      row-key="idComment"
      :columns="columns"
    >
  <template v-slot:body-cell-author="props">
    <q-input
      borderless
      standout
      :dense=true
      readonly
      :model-value="getSpaced(props.row.author.firstName, props.row.author.lastName)"
      />
  </template>
</q-table>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import axios from 'axios'
import { BASE_URL } from '../api.config'

export default defineComponent({
  name: 'CommentList',

  data () {
    return {
      comments: [],
      columns: [
        {
          name: 'title',
          required: true,
          label: 'Title',
          align: 'left',
          field: 'title'
        },
        {
          name: 'description',
          required: true,
          label: 'Description',
          align: 'left',
          field: 'description'
        },
        {
          name: 'dateTimeCreated',
          required: true,
          label: 'Date Created',
          align: 'left',
          field: 'dateTimeCreated',
          format: (val) => {
            const date = new Date(val)
            const day = date.getDate()
            const month = new Intl.DateTimeFormat('en-US', { month: 'short' }).format(date)
            const year = date.getFullYear()
            return `${day} ${month} ${year}`
          }
        },
        {
          name: 'author',
          required: true,
          label: 'Author',
          align: 'left'
        }
      ]
    }
  },

  methods: {
    async fetchCommentsList () {
      try {
        const response = await axios.get(`${BASE_URL}/comments/list`)
        this.comments = response.data
        console.log(this.comments) // Log the comments array after setting it
      } catch (error) {
        console.error('Error fetching comments list:', error)
      }
    },

    getSpaced (firstValue:string, secondValue:string): string {
      return firstValue + ' ' + secondValue
    }
  },

  mounted () {
    this.fetchCommentsList()
  }
})
</script>
