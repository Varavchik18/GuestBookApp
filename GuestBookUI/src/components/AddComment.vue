<template>
  <div class="q-pa-md">
    <q-card class="q-pa-xl">
      <q-form @submit.prevent="addComment">
        <div class="form-group">
          <q-input
            stack-label
            label="Title"
            v-model="title"
            :rules="titleRules"
            autogrow
            clearable
          />
        </div>

        <div class="form-group">
          <q-input
            stack-label
            label="Description"
            v-model="description"
            :rules="descriptionRules"
            autogrow
            clearable
            counter
          />
        </div>

        <div class="form-group">
          <q-input
            stack-label
            label="Image Url"
            v-model="imageUrl"
            :rules="imageUrlRules"
            autogrow
            clearable
            type="url"
          />
        </div>

        <div class="form-group">
          <q-select
            label="Author"
            stack-label
            transition-show="flip-up"
            transition-hide="flip-down"
            v-model="authorId"
            :options="authorOptions"
            :rules="[authorRules]"
          />
        </div>

        <div>
          <q-btn :disabled="hasActiveErrors" label="Submit" type="submit" color="primary"/>
          <q-btn label="Reset" type="reset" color="primary" flat class="q-ml-sm" />
        </div>

      </q-form>
    </q-card>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue'
import { Notify } from 'quasar'
import axios from 'axios'
import { BASE_URL } from '../api.config'
import { IAuthor } from './types'

export default defineComponent({
  name: 'AddComment',

  data () {
    return {
      title: ref(''),
      description: ref(''),
      imageUrl: ref(''),
      authorId: ref(null as number | null),
      authors: [] as IAuthor[]
    }
  },

  computed: {
    authorOptions (): any[] {
      return this.authors.map((author) => ({
        value: author.idAuthor,
        label: `${author.firstName} ${author.lastName}`
      }))
    },

    titleRules () {
      return [
        (v) => !!v || 'Title is required.',
        (v) => (v && v.length <= 50) || 'Title should be less than 50 characters.'
      ]
    },
    descriptionRules () {
      return [
        (v) => !v || v.length <= 500 || 'Description should be less than 500 characters.'
      ]
    },
    imageUrlRules () {
      return [
        (v) => !v || v.length <= 500 || 'Image URL should be less than 500 characters.'
      ]
    },
    authorRules () {
      return (v) => !!v || 'Author is required.'
    },
    isTitleValid () {
      return this.title && this.title.length <= 50
    },
    isDescriptionValid () {
      return !this.description || this.description.length <= 500
    },
    isAuthorValid () {
      return this.authorId
    },
    hasActiveErrors () {
      return !this.isTitleValid || !this.isDescriptionValid
    }
  },

  methods: {
    async addComment () {
      try {
        const response = await axios.post(`${BASE_URL}/comments/create`, {
          title: this.title,
          description: this.description,
          imageUrl: this.imageUrl,
          authorId: parseInt(this.authorId.value)
        })

        this.showSucceedMessage('Comment added successfully!')

        this.$router.push({ name: 'home' })
      } catch (error) {
        if (error.response.data) { this.showErrorMessage(error, 'Error adding comment: ') } else { this.showErrorMessage(error, 'Error adding comment: ') }
      }
    },

    showErrorMessage (error: any, message: string): void {
      Notify.create({
        message: `${message} ${error.response.data}`,
        color: 'negative',
        icon: 'warning'
      })
    },

    showSucceedMessage (message: string): void {
      Notify.create({
        message: `${message}`,
        color: 'positive',
        icon: 'check'
      })
    }
  },

  async mounted () {
    const response = await axios.get<IAuthor[]>(`${BASE_URL}/authors/list`)
    this.authors = response.data
  }
})
</script>

<style>
.form-group {
  margin-bottom: 10px;
}
</style>
